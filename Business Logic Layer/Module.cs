using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRG282_Milestone_2.Data_Access_Layer;

namespace PRG282_Milestone_2.Business_Logic_Layer
{
    class Module
    {
        private string moduleCode;
        private string name;
        private string description;
        private string ytLinks;


        public string ModuleCode { get => moduleCode; set => moduleCode = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string YtLinks { get => ytLinks; set => ytLinks = value; }


        public Module(string moduleCode, string name, string description, string ytLinks)
        {
            this.ModuleCode = moduleCode;
            this.Name = name;
            this.Description = description;
            this.YtLinks = ytLinks;


        }

        public Module()
        {
            


        }

        public void Create(string moduleCode, string name, string description, string ytLinks)
        {
            FileHandler fh = new FileHandler();
            fh.createModule(moduleCode, name, description, ytLinks);
        }

        public List<Module> getModuleByCode(string moduleCode)
        {
            FileHandler fh = new FileHandler();
            return fh.SearchModule(moduleCode);
        }

        public void deleteModule(string moduleCode)
        {
            FileHandler fh = new FileHandler();
            fh.deleteModule(moduleCode);
        }

        public void Update(string moduleCode, string name, string description, string ytLinks)
        {
            FileHandler fh = new FileHandler();
            fh.UpdateModule(moduleCode, name, description, ytLinks);

        }
    }
}
