using System;
using System.Collections.Generic;
using System.IO;
using static System.Console;

namespace OpenClosedPrinciple
{


    public enum Roles
    {
        Admin,
        Operator,
        Executive,
        Subscriber

    }

    public enum Permissions
    {
        Read,
        Write,
        Execute

    }

    public class UserPermissions
    {

        public string Name;
        public Permissions Permission;
        public Roles Role;
        public UserPermissions(string name, Permissions permission, Roles role)
        {
            Name = name;
            Permission = permission;
            Role = role;
        }


    }
    public interface IPermissionCriteria<T>
    {
        bool isConditionSatisfied(T t);
    }

    public interface IFilter<T>{

        IEnumerable<T> Filter(IEnumerable<T> items, IPermissionCriteria<T> permissions);
    }

    public class RWEPermission: IPermissionCriteria<UserPermissions>{

            private Permissions Permission;

            public RWEPermission(Permissions permission){
                Permission = permission;
            }

            public bool isConditionSatisfied(UserPermissions permit){

                return permit.Permission == Permission;
            }

            
    }

    public class BetterFilter : IFilter<UserPermissions>{

        public IEnumerable<UserPermissions> Filter (IEnumerable<UserPermissions> items, IPermissionCriteria<UserPermissions> permissions){

            foreach(var i in items){
                if(permissions.isConditionSatisfied(i)){
                    yield return i;
                }
            }
        }
    }


    public class CombinePermissions<T> : IPermissionCriteria<T>{

        private IPermissionCriteria<T> first, second;

        public CombinePermissions(IPermissionCriteria<T> first, IPermissionCriteria<T> second){

            this.first = first ?? throw new ArgumentNullException(paramName: nameof(first));
            this.second = second ?? throw new ArgumentNullException(paramName: nameof(second));
        }

        public bool isConditionSatisfied(T t){
            return first.isConditionSatisfied(t) || second.isConditionSatisfied(t);
        }
    }



    public class Program
    {

        static void Main(string[] args)
        {
            var Europe = new UserPermissions("Europeans", Permissions.Read, Roles.Executive);
            var Asia = new UserPermissions("Asian", Permissions.Write, Roles.Operator);
            var America = new UserPermissions("America", Permissions.Execute, Roles.Admin);

            UserPermissions[] userPermissions = {Europe, America, Asia};

            Console.WriteLine("Execute Filer");

            var bf = new BetterFilter();

            foreach(var permission in bf.Filter(userPermissions, new RWEPermission(Permissions.Execute))){

                Console.WriteLine($"- {permission.Name}");
            }

            foreach(var p in bf.Filter(

                userPermissions,
                new CombinePermissions<UserPermissions>(
                    new RWEPermission(Permissions.Execute),
                    new RWEPermission(Permissions.Write)
                )
            ))
            {
                 Console.WriteLine($"- {p.Name}");
            }
        }
    }


}