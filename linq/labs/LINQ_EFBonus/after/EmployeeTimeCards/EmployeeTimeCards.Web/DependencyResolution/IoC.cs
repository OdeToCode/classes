using EmployeeTimeCards.Core;
using EmployeeTimeCards.Web.Infrastructure;
using StructureMap;
namespace EmployeeTimeCards.Web {
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });
                            x.For<IUnitOfWork>().Use<SqlUnitOfWork>();
                        });
            return ObjectFactory.Container;
        }
    }
}