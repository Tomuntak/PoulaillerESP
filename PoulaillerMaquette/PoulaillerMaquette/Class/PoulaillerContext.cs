using System;


namespace PoulaillerMaquette.Class
{
    public partial class PoulaillerContext 
    {

        public PoulaillerContext()
        {
        }

        //public PoulaillerContext(DbContextOptions<PoulaillerContext> options);

        public object Poules { get; internal set; }


    }

}
