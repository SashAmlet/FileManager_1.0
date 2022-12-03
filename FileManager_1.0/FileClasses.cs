using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_1._0
{
    abstract class Component // абстрактний клас, який описує компонент (чи то папка чи то файл)
    {
        public Component(string name)
        {
            Name= name;
        }
        public string Name{ get; set; }

        public virtual void Add(Component component) { }
        public virtual void Remove(Component component) { }
    }
    class Folder : Component // клас, який описує папки
    {
        private List<Component> components = new List<Component>();

        public Folder(string name) : base(name)
        {
        }

        public override void Add(Component component)
        {
            components.Add(component);
        }
        public List<Component> Get()
        {
            return components;
        }

        public override void Remove(Component component)
        {
            components.Remove(component);
        }
    }

    class File : Component // клас, який описує файли
    {
        public string filePath { get; set; }

        public File(string name) : base(name)
        { }
        public Component Get()
        {
            return this;
        }
    }
}
