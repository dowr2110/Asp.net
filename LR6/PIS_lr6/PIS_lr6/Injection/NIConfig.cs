using Ninject.Modules;
using Ninject.Web.Common;
using Storage;

namespace PIS_lr6.Injection
{
    public class NIConfig : NinjectModule
    {
        public override void Load()
        {
            //Bind<IElementsDictionary<Telephone>>().To<TelephoneStorage>().InTransientScope();
            //  InTransientScope - по умолчанию, создается на каждое внедрение

            //Bind<IElementsDictionary<Telephone>>().To<TelephoneStorage>().InThreadScope(); 
            //Замените тип внедрения, при котором объект репозитория создается для каждого потока выполнения. 
            //  InThreadScope - один объект на один поток

            //Bind<IElementsDictionary<Telephone>>().To<TelephoneStorage>().InRequestScope();
            //  InRequestScope - для одного HTTP один объект

            Bind<IElementsDictionary<Telephone>>().To<TelephoneStorageEF>().InRequestScope();
            //  InRequestScope - для одного HTTP один объект


        }
    }
}