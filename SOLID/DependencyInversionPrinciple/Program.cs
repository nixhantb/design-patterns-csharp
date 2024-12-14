using System;
using System.IO;
using System.Collections.Generic;

using System.Linq;

namespace DependencyInversionPrinciple{

    public enum Relationship{
        Parent, 
        Child, 
        Sibling
    }

    public class Person{
        public string Name;
    }

    // some low level modules

    public interface IRelationshipBrowser{

        IEnumerable<Person> FindAllChildrenOf(string name);
    }

    public class Relationships: IRelationshipBrowser{
        
        private List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)>();

        public void AddParentAndChild(Person parent, Person child){

            relations.Add((parent, Relationship.Parent, child));
            relations.Add((child, Relationship.Child, parent));
        }

        public IEnumerable<Person> FindAllChildrenOf(string name){

                return relations.Where(
                    x => x.Item1.Name == name && x.Item2 == Relationship.Parent).Select(r => r.Item3);
                
        }


    }

    public class Program {
        
        public Program(IRelationshipBrowser browser){

            foreach(var p in browser.FindAllChildrenOf("John")){
                Console.WriteLine($"John has a child called {p.Name}");
            }
        }
        static void Main(string[] args){
            var parent = new Person { Name = "John" };
            var child1 = new Person { Name = "Chris" };
            var child2 = new Person { Name = "Mary" };

            var relationships = new Relationships();

            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(parent, child2);
            new Program(relationships);
        }
    }
}