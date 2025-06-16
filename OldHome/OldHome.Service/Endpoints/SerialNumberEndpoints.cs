namespace OldHome.Service.Endpoints
{
    public static class SerialNumberEndpoints
    {
        public static void MapSerialNumberEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/serialnumbers");
            EndpointsHelper.GetAll<SerialNumberDto, SerialNumber>(group);
            EndpointsHelper.GetAllSamples<SerialNumberSample, SerialNumber>(group, authorize: false);
            EndpointsHelper.Create<SerialNumberCreate, SerialNumber, SerialNumberDto>(group);
            EndpointsHelper.Modify<SerialNumberModify, SerialNumber>(group);
            EndpointsHelper.Delete<SerialNumber>(group);
        }
    }
}
