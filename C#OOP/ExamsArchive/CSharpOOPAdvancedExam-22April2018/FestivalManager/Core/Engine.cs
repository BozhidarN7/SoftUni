
using System;
using System.Linq;
namespace FestivalManager.Core
{
    using System.Reflection;
    using Contracts;
    using Controllers;
    using Controllers.Contracts;
    using IO.Contracts;

    /// <summary>
    /// by g0shk0
    /// </summary>
    class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;

        public Engine(IFestivalController festivalController, ISetController setController)
        {
            this.festivalCоntroller = festivalController;
            this.setCоntroller = setController;
        }

        // дайгаз
        public void Run()
        {

        }

        public string ProcessCommand(string input)
        {
            return "";
        }
    }
}