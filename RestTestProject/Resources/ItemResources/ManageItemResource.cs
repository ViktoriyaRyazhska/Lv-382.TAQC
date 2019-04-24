using RestTestProject.Data;
using RestTestProject.Entity;


namespace RestTestProject.Resources
{
    public class ManageItemResource : ARestCrud<SimpleEntity>
    {
        public ManageItemResource() : base(RestUrlRepository.ManageItem())
        {
        }

    }
}
