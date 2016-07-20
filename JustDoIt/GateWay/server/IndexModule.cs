namespace GateWay.server
{
    public class IndexModule : Nancy.NancyModule
    {
        public IndexModule()
        {
            Get["/"] = _ => View["index"];
        }
    }
}
