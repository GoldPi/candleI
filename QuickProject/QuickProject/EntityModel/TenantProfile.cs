namespace EntityModel
{
    public class TenantProfile : BaseEntity<string>
    {
        public string Name { get; set; }
        public string Host { get; set; }
        public string Module { get; set; }
        public string[] Hosts =>string.IsNullOrWhiteSpace(Host)?new string[0]: Host.Split('|');
        public string[] Modules => string.IsNullOrWhiteSpace(Module) ? new string[0] : Module.Split('|');
    }


}
