using System;
namespace VantageLibrary.Types; 
public class VantageCategoryCreation {
    public class Category {
        public string Identifier { get; set; }
        public string Name { get; set; }
        public List<VantageWorkflow> Workflows { get; set; }
    }
}
