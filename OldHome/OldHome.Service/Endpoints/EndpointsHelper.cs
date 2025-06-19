using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OldHome.DAL;
using OldHome.DTO;
using OldHome.DTO.Base;
using OldHome.Entities;
using OldHome.Entities.Base;
using System.Linq.Expressions;
using OldHome.Service.Helpers;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace OldHome.Service.Endpoints
{
    public static class EndpointsHelper
    {
        public static void GetAllSamples<T, E>(RouteGroupBuilder group, Func<IQueryable<E>, IQueryable<E>>[] includes = null, bool authorize = true) where T : BaseDto where E : BaseEntity
        {
            var req = group.MapGet("/samples", async (AppDataContext db, IMapper mapper, HttpRequest request) =>
            {
                IQueryable<E> set = db.Set<E>();
                if (typeof(BaseOrgByEntity).IsAssignableFrom(typeof(E)))
                {
                    var orgIdStr = request.Headers["OrgId"].FirstOrDefault();
                    if (int.TryParse(orgIdStr, out int orgId))
                    {
                        set = set.Where(BuildOrgIdFilter<E>(orgId));
                    }
                }
                if (includes != null)
                    foreach (var include in includes)
                    {
                        set = include(set);
                    }
                Expression<Func<E, bool>> predicate = u => false;
                // 根据 URL 查询字符串参数动态构建筛选条件
                bool r = false;
                foreach (var (key, value) in request.Query)
                {
                    if (typeof(E).GetProperty(key.Split('_')[0]) != null)
                    {
                        predicate = predicate.Or(BuildPredicate<E>(key, value!));
                        r = true;
                    }
                }
                if (r)
                    set = set.Where(predicate);
                var items = await set.ToListAsync();
                var t = typeof(T);
                List<T> samples = mapper.Map<List<T>>(items);
                return Results.Ok(samples);
            });
            if (authorize)
            {
                req.RequireAuthorization();
            }
        }

        public static void GetTop10Samples<T, E>(RouteGroupBuilder group, Func<IQueryable<E>, IQueryable<E>>[] includes = null, bool authorize = true) where T : BaseDto where E : BaseEntity
        {
            var req = group.MapGet("/top10samples", async (AppDataContext db, IMapper mapper, HttpRequest request) =>
            {
                try
                {
                    IQueryable<E> set = db.Set<E>();
                    if (typeof(BaseOrgByEntity).IsAssignableFrom(typeof(E)))
                    {
                        var orgIdStr = request.Headers["OrgId"].FirstOrDefault();
                        if (int.TryParse(orgIdStr, out int orgId))
                        {
                            set = set.Where(BuildOrgIdFilter<E>(orgId));
                        }
                    }
                    if (includes != null)
                        foreach (var include in includes)
                        {
                            set = include(set);
                        }
                    Expression<Func<E, bool>> predicate = u => true;
                    // 根据 URL 查询字符串参数动态构建筛选条件
                    foreach (var (key, value) in request.Query)
                    {
                        if (typeof(E).GetProperty(key.Split('_')[0]) != null)
                        {
                            predicate.Or(BuildPredicate<E>(key, value!));
                        }
                    }
                    set = set.Where(predicate);
                    var items = await set.Take(10).ToListAsync();
                    List<T> samples = mapper.Map<List<T>>(items);
                    return Results.Ok(samples);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });

            if (authorize)
            {
                req.RequireAuthorization();
            }
        }


        public static void GetAll<T, E>(RouteGroupBuilder group,
            Func<IQueryable<E>, IQueryable<E>>[] includes = null,
            bool authorize = true)
            where T : BaseDto where E : BaseEntity
        {
            var route = group.MapGet("/", async (
                AppDataContext db,
                IMapper mapper,
                HttpRequest request) =>
            {
                try
                {

                    IQueryable<E> set = db.Set<E>();
                    if (typeof(BaseOrgByEntity).IsAssignableFrom(typeof(E)))
                    {
                        var orgIdStr = request.Headers["OrgId"].FirstOrDefault();
                        if (int.TryParse(orgIdStr, out int orgId))
                        {
                            set = set.Where(BuildOrgIdFilter<E>(orgId));
                        }
                    }
                    int totalCount = await set.CountAsync();
                    if (includes != null)
                        foreach (var include in includes)
                        {
                            set = include(set);
                        }
                    foreach (var (key, value) in request.Query)
                    {
                        if (typeof(E).GetProperty(key.Split('_')[0]) != null)
                        {
                            set = set.Where(BuildPredicate<E>(key, value!));
                        }
                    }

                    List<E> items = await set.ToListAsync();
                    var mapped = mapper.Map<List<T>>(items);
                    return Results.Ok(mapped);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });
            if (authorize) route.RequireAuthorization();
        }

        public static void GetPage<T, E>(RouteGroupBuilder group,
            Func<IQueryable<E>, IQueryable<E>>[] includes = null,
            bool authorize = true)
            where T : BaseDto where E : BaseEntity
        {
            var route = group.MapGet("/paged", async (
                AppDataContext db,
                IMapper mapper,
                HttpRequest request,
                int pageIndex,
                int pageSize) =>
            {
                try
                {
                    IQueryable<E> set = db.Set<E>();
                    if (typeof(BaseOrgByEntity).IsAssignableFrom(typeof(E)))
                    {
                        var orgIdStr = request.Headers["OrgId"].FirstOrDefault();
                        if (int.TryParse(orgIdStr, out int orgId))
                        {
                            set = set.Where(BuildOrgIdFilter<E>(orgId));
                        }
                    }
                    int totalCount = await set.CountAsync();
                    if (includes != null)
                        foreach (var include in includes)
                        {
                            set = include(set);
                        }
                    string[] ops = { "eq", "neq", "gt", "gte", "lt", "lte", "like" };
                    foreach (var (key, value) in request.Query)
                    {
                        string[] ar = key.Split('_');
                        if (ar[0].Equals("or"))
                        {
                            set.Where(BuilderOrPredicate<E>(key, value!));
                        }
                        else
                        {
                            if (typeof(E).GetProperty(ar[0]) != null)
                            {
                                set = set.Where(BuildPredicate<E>(key, value!));
                            }
                        }
                    }

                    List<E> items = await set.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

                    var result = new PagedResult<T>()
                    {
                        TotalCount = totalCount,
                        PageIndex = pageIndex,
                        PageSize = pageSize,
                        Items = mapper.Map<List<T>>(items)
                    };
                    return Results.Ok(result);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });
            if (authorize) route.RequireAuthorization();
        }

        public static Expression<Func<T, bool>> BuilderOrPredicate<T>(string key, string value)
        {
            string[] ops = { "eq", "neq", "gt", "gte", "lt", "lte", "like" };
            string[] parts = key.Split('_');

            var parameter = Expression.Parameter(typeof(T), "x");
            Expression<Func<T, bool>> predicate = u => false;
            int opi = parts.ToList().FindIndex(p => ops.Contains(p));
            string operation = parts[opi];
            for (int i = 1; i < opi; i++)
            {
                string propertyName = parts[i];
                var property = Expression.Property(parameter, propertyName);
                var propertyType = property.Type;
                // 转换值
                object typedValue = Convert.ChangeType(value, Nullable.GetUnderlyingType(propertyType) ?? propertyType);
                var constant = Expression.Constant(typedValue, property.Type);

                Expression body = operation switch
                {
                    "eq" => Expression.Equal(property, constant),
                    "neq" => Expression.NotEqual(property, constant),
                    "gt" => Expression.GreaterThan(property, constant),
                    "gte" => Expression.GreaterThanOrEqual(property, constant),
                    "lt" => Expression.LessThan(property, constant),
                    "lte" => Expression.LessThanOrEqual(property, constant),
                    "like" => BuildLikeExpression(property, value),
                    _ => throw new NotSupportedException($"不支持的操作符：{operation}")
                };

                if (typeof(T).GetProperty(propertyName) != null)
                    predicate = predicate.Or(Expression.Lambda<Func<T, bool>>(body, parameter));
            }
            return predicate;
        }

        public static Expression<Func<T, bool>> BuildPredicate<T>(string key, string value)
        {
            var parameter = Expression.Parameter(typeof(T), "x");

            // 解析字段和操作符
            string[] parts = key.Split('_', 2);
            string propertyName = parts[0];
            string operation = parts.Length > 1 ? parts[1].ToLower() : "eq";

            var property = Expression.Property(parameter, propertyName);
            var propertyType = property.Type;

            // 转换值
            object typedValue = Convert.ChangeType(value, Nullable.GetUnderlyingType(propertyType) ?? propertyType);
            var constant = Expression.Constant(typedValue, property.Type);

            Expression body = operation switch
            {
                "eq" => Expression.Equal(property, constant),
                "neq" => Expression.NotEqual(property, constant),
                "gt" => Expression.GreaterThan(property, constant),
                "gte" => Expression.GreaterThanOrEqual(property, constant),
                "lt" => Expression.LessThan(property, constant),
                "lte" => Expression.LessThanOrEqual(property, constant),
                "like" => BuildLikeExpression(property, value),
                _ => throw new NotSupportedException($"不支持的操作符：{operation}")
            };

            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }

        private static Expression BuildLikeExpression(MemberExpression property, string value)
        {
            var method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            var toLowerMethod = typeof(string).GetMethod("ToLower", Type.EmptyTypes);

            // 确保是字符串
            if (property.Type != typeof(string))
                throw new NotSupportedException("like 操作仅支持 string 类型");

            var propertyToLower = Expression.Call(property, toLowerMethod);
            var constant = Expression.Constant(value.ToLower());

            return Expression.Call(propertyToLower, method!, constant);
        }

        public static void Modify<T, E>(RouteGroupBuilder group, bool authorize = true) where T : BaseDto where E : BaseEntity
        {
            var req = group.MapPost("/modify", async (AppDataContext db, IMapper mapper, T dto, HttpContext httpContext) =>
            {
                try
                {
                    E? item;
                    item = await db.Set<E>().FirstOrDefaultAsync(p => p.Id == dto.Id);

                    if (item == null)
                    {
                        return Results.NotFound();
                    }

                    var userName = httpContext.User.FindFirst(ClaimTypes.Name)?.Value ?? "";
                    dto.UpdateAt = DateTime.UtcNow;
                    dto.UpdateBy = userName;
                    mapper.Map(dto, item);
                    await db.SaveChangesAsync();
                    return Results.Ok();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });
            if (authorize)
            {
                req.RequireAuthorization();
            }
        }

        public static void ModifyItems<T, E, ItemE>(RouteGroupBuilder group, bool authorize = true)
            where T : BaseDto
            where E : BaseItemsOrgByEntity<ItemE>
            where ItemE : BaseEntity
        {
            var req = group.MapPost("/modify-items", async (AppDataContext db, IMapper mapper, T dto, HttpContext httpContext) =>
            {
                try
                {
                    E? entity;
                    entity = await db.Set<E>().Include(p => p.Items).FirstOrDefaultAsync(p => p.Id == dto.Id);

                    if (entity == null)
                    {
                        return Results.NotFound();
                    }

                    var userName = httpContext.User.FindFirst(ClaimTypes.Name)?.Value ?? "";
                    dto.UpdateAt = DateTime.UtcNow;
                    dto.UpdateBy = userName;
                    mapper.Map(dto, entity);
                    await db.SaveChangesAsync();
                    return Results.Ok();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });
            if (authorize)
            {
                req.RequireAuthorization();
            }
        }


        public static void Create<T, E, R>(RouteGroupBuilder group, bool authorize = true) where T : BaseDto where E : BaseEntity where R : class
        {
            var req = group.MapPost("/create", async (AppDataContext db, IMapper mapper, T dto, HttpContext httpContext, HttpRequest request) =>
            {
                try
                {
                    var userName = httpContext.User.FindFirst(ClaimTypes.Name)?.Value ?? "";

                    dto.CreatedAt = DateTime.UtcNow;
                    dto.UpdateAt = DateTime.UtcNow;
                    dto.CreatedBy = userName;
                    dto.UpdateBy = userName;

                    if (dto is BaseOrgByDto orgDto)
                    {
                        orgDto.OrgId = Convert.ToInt32(request.Headers["OrgId"].ToString());
                        var entity = mapper.Map<E>(orgDto);
                        var result = await db.Set<E>().AddAsync(entity);
                        await db.SaveChangesAsync();
                        return Results.Ok(mapper.Map<R>(result.Entity));
                    }
                    else
                    {
                        var entity = mapper.Map<E>(dto);
                        var result = await db.Set<E>().AddAsync(entity);
                        await db.SaveChangesAsync();
                        return Results.Ok(mapper.Map<R>(result.Entity));
                    }

                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });
            if (authorize)
            {
                req.RequireAuthorization();
            }
        }

        public static void Delete<E>(RouteGroupBuilder group, bool authorize = true) where E : class
        {
            var req = group.MapGet("/delete", async (AppDataContext db, int id) =>
            {
                try
                {
                    var item = await db.Set<E>().FindAsync(id);
                    if (item == null)
                    {
                        return Results.NotFound();
                    }
                    db.Set<E>().Remove(item);
                    await db.SaveChangesAsync();
                    return Results.Ok();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });
            if (authorize)
            {
                req.RequireAuthorization();
            }
        }

        public static Expression<Func<T, bool>> BuildOrgIdFilter<T>(int orgId) where T : BaseEntity
        {
            var parameter = Expression.Parameter(typeof(T), "p");
            var cast = Expression.Convert(parameter, typeof(BaseOrgByEntity));
            var property = Expression.Property(cast, nameof(BaseOrgByEntity.OrgId));
            var constant = Expression.Constant(orgId);
            var equal = Expression.Equal(property, constant);
            return Expression.Lambda<Func<T, bool>>(equal, parameter);
        }
    }
}
