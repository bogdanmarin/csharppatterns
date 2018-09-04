using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Creational.FactoryMethod
{
    public abstract class Document
    {
        private List<Page> _pages = new List<Page>();
        public Document()
        {
            this.CreatePages();
        }

        public abstract void CreatePages();

        public List<Page> Pages
        {
            get
            {
                return _pages;
            }
        }
    }
}
