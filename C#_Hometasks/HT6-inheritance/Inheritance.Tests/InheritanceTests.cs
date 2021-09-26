using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Inheritance.Tests
{
    [TestFixture]
    public class InheritanceTests
    {
        #region low

        [TestCase("Employee")]
        [TestCase("Manager")]
        [TestCase("SalesPerson")]
        public void ClassExist(string className)
        {
            GetClass(className);
        }

        [TestCase("Employee", "name", typeof(string))]
        [TestCase("Employee", "salary", typeof(decimal))]
        [TestCase("Employee", "bonus", typeof(decimal))]
        [TestCase("Manager", "quantity", typeof(int))]
        [TestCase("SalesPerson", "percent", typeof(int))]
        public void FieldExist(string className, string fieldName, Type fieldType)
        {
            var classType = GetClass(className);
            var field = classType.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.Multiple(() =>
            {
                Assert.That(field, Is.Not.Null);
                Assert.That(field.FieldType, Is.EqualTo(fieldType));
            });
        }

        [TestCase("Employee", "Name", typeof(string), false)]
        [TestCase("Employee", "Salary", typeof(decimal), true)]
        public void PropertyExist(string className, string propertyName, Type propertyType, bool isWriteable,
            bool isReadable = true)
        {
            var classType = GetClass(className);
            var property = classType.GetProperty(propertyName);
            Assert.Multiple(() =>
            {
                Assert.That(property, Is.Not.Null);
                Assert.That(property.PropertyType, Is.EqualTo(propertyType));
                Assert.That(property.CanRead, Is.EqualTo(isReadable));
                Assert.That(property.CanWrite, Is.EqualTo(isWriteable));
            });
        }

        [TestCaseSource("ConstructorData")]
        public void ConstructorExist(string className, (string, Type)[] constructorTypes)
        {
            var classType = GetClass(className);
            var constructor = classType.GetConstructor(constructorTypes.Select(x => x.Item2).ToArray());
            Assert.Multiple(() =>
            {
                Assert.That(constructor, Is.Not.Null);
                Assert.That(constructor.GetParameters()
                    .Select(x => (x.Name, x.ParameterType)).SequenceEqual(constructorTypes),
                    Is.True);
            });
        }

        [TestCaseSource("MethodsData")]
        public void MethodExist(string className, string methodName, Type returnType, (string, Type)[] parameters)
        {
            var classType = GetClass(className);
            var method = classType.GetMethod(methodName);
            Assert.Multiple(() =>
            {
                Assert.That(method, Is.Not.Null);
                Assert.That(method.ReturnType, Is.EqualTo(returnType));
                Assert.That(method.GetParameters()
                        .Select(x => (x.Name, x.ParameterType)).SequenceEqual(parameters),
                    Is.True);
            });
        }

        [TestCase("Manager")]
        [TestCase("SalesPerson")]
        public void InheritanceCheck(string className)
        {
            var employeeType = GetClass("Employee");
            var classType = GetClass(className);
            Assert.That(classType.BaseType, Is.EqualTo(employeeType));
        }

        [TestCase("Manager", "SetBonus")]
        [TestCase("SalesPerson", "SetBonus")]
        public void VirtualMethodCheck(string className, string methodName)
        {
            var employeeType = GetClass("Employee");
            var classType = GetClass(className);
            Assert.Multiple(() =>
            {
                Assert.That(classType.BaseType, Is.EqualTo(employeeType));
                Assert.That(employeeType.GetMethod(methodName), Is.Not.Null);
                Assert.That(classType.GetMethod(methodName), Is.Not.Null);
                Assert.That(employeeType.GetMethod(methodName).IsVirtual, Is.True);
                Assert.That(classType.GetMethod(methodName).DeclaringType, Is.Not.EqualTo(employeeType));
            });
        }

        [Test]
        public void EmployeeFunctionalTest()
        {
            var classType = GetClass("Employee");
            var constructor = classType.GetConstructor(new[] { typeof(string), typeof(decimal) });
            Assert.Multiple(() =>
            {
                Assert.That(constructor, Is.Not.Null);
                var el = constructor.Invoke(new object[] { "name", (decimal)14 });
                var setBonus = classType.GetMethod("SetBonus");
                Assert.That(setBonus, Is.Not.Null);
                setBonus.Invoke(el, new object[] { (decimal)5 });
                var toPay = classType.GetMethod("ToPay");
                Assert.That(toPay, Is.Not.Null);
                var res = toPay.Invoke(el, new object[0]);
                Assert.That(res, Is.InstanceOf<decimal>());
                Assert.That((decimal)res, Is.EqualTo((decimal)19));
                var salary = classType.GetProperty("Salary");
                Assert.That(salary, Is.Not.Null);
                salary.SetMethod.Invoke(el, new object[] { (decimal)45 });
                Assert.That((decimal)salary.GetMethod.Invoke(el, new object[0]),
                    Is.EqualTo((decimal)45));
                res = toPay.Invoke(el, new object[0]);
                Assert.That((decimal)res, Is.EqualTo((decimal)50));
                var nameProperty = classType.GetProperty("Name");
                Assert.That(nameProperty, Is.Not.Null);
                Assert.That((string)nameProperty.GetMethod.Invoke(el, new object[0]),
                    Is.EqualTo("name"));
            });
        }

        [TestCase(200, 1000)]
        [TestCase(110, 500)]
        [TestCase(25, 0)]
        public void ManagerFunctionalTest(int quantity, decimal bonus)
        {
            var classType = GetClass("Manager");
            var constructor = classType.GetConstructor(new[] { typeof(string), typeof(decimal), typeof(int) });
            Assert.Multiple(() =>
            {
                Assert.That(constructor, Is.Not.Null);
                var el = constructor.Invoke(new object[] { "name", (decimal)14, quantity });
                var setBonus = classType.GetMethod("SetBonus");
                Assert.That(setBonus, Is.Not.Null);
                setBonus.Invoke(el, new object[] { (decimal)0 });
                var toPay = classType.GetMethod("ToPay");
                Assert.That(toPay, Is.Not.Null);
                var res = toPay.Invoke(el, new object[0]);
                Assert.That(res, Is.InstanceOf<decimal>());
                Assert.That((decimal)res, Is.EqualTo((decimal)14 + bonus));
                var salary = classType.GetProperty("Salary");
                Assert.That(salary, Is.Not.Null);
                salary.SetMethod.Invoke(el, new object[] { (decimal)45 });
                Assert.That((decimal)salary.GetMethod.Invoke(el, new object[0]),
                    Is.EqualTo((decimal)45));
                res = toPay.Invoke(el, new object[0]);
                Assert.That((decimal)res, Is.EqualTo((decimal)45 + bonus));
                var nameProperty = classType.GetProperty("Name");
                Assert.That(nameProperty, Is.Not.Null);
                Assert.That((string)nameProperty.GetMethod.Invoke(el, new object[0]),
                    Is.EqualTo("name"));
            });
        }

        [TestCase(220, 30)]
        [TestCase(110, 20)]
        [TestCase(25, 10)]
        public void SalesPersonFunctionalTest(int percent, decimal bonus)
        {
            var classType = GetClass("SalesPerson");
            var constructor = classType.GetConstructor(new[] { typeof(string), typeof(decimal), typeof(int) });
            Assert.Multiple(() =>
            {
                Assert.That(constructor, Is.Not.Null);
                var el = constructor.Invoke(new object[] { "name", (decimal)14, percent });
                var setBonus = classType.GetMethod("SetBonus");
                Assert.That(setBonus, Is.Not.Null);
                setBonus.Invoke(el, new object[] { (decimal)10 });
                var toPay = classType.GetMethod("ToPay");
                Assert.That(toPay, Is.Not.Null);
                var res = toPay.Invoke(el, new object[0]);
                Assert.That(res, Is.InstanceOf<decimal>());
                Assert.That((decimal)res, Is.EqualTo((decimal)14 + bonus));
                var salary = classType.GetProperty("Salary");
                Assert.That(salary, Is.Not.Null);
                salary.SetMethod.Invoke(el, new object[] { (decimal)45 });
                Assert.That((decimal)salary.GetMethod.Invoke(el, new object[0]),
                    Is.EqualTo((decimal)45));
                res = toPay.Invoke(el, new object[0]);
                Assert.That((decimal)res, Is.EqualTo((decimal)45 + bonus));
                var nameProperty = classType.GetProperty("Name");
                Assert.That(nameProperty, Is.Not.Null);
                Assert.That((string)nameProperty.GetMethod.Invoke(el, new object[0]),
                    Is.EqualTo("name"));
            });
        }

        private static IEnumerable<TestCaseData> MethodsData
        {
            get
            {
                yield return new TestCaseData("Employee", "SetBonus", typeof(void),
                    new[] { ("bonus", typeof(decimal)) });
                yield return new TestCaseData("SalesPerson", "SetBonus", typeof(void),
                    new[] { ("bonus", typeof(decimal)) });
                yield return new TestCaseData("Manager", "SetBonus", typeof(void),
                    new[] { ("bonus", typeof(decimal)) });
                yield return new TestCaseData("Employee", "ToPay", typeof(decimal),
                    new List<(string, Type)>().ToArray());
                yield return new TestCaseData("SalesPerson", "ToPay", typeof(decimal),
                    new List<(string, Type)>().ToArray());
                yield return new TestCaseData("Manager", "ToPay", typeof(decimal),
                    new List<(string, Type)>().ToArray());
            }
        }

        private static IEnumerable<TestCaseData> ConstructorData
        {
            get
            {
                yield return new TestCaseData("Employee",
                    new[] { ("name", typeof(string)), ("salary", typeof(decimal)) });
                yield return new TestCaseData("Manager",
                    new[] { ("name", typeof(string)), ("salary", typeof(decimal)), ("clientAmount", typeof(int)) });
                yield return new TestCaseData("SalesPerson",
                    new[] { ("name", typeof(string)), ("salary", typeof(decimal)), ("percent", typeof(int)) });
            }
        }

        #endregion

        #region advance
        // UNCOMMENT TO CHECK ADVANCED PART

        [Test]
        public void CompanyClassExist()
        {
            GetClass("Company");
        }

        [Test]
        public void CompanyClassEmployeesFieldExist()
        {
            var classType = GetClass("Company");
            var employeeClass = GetClass("Employee");
            var field = classType.GetField("employees", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.Multiple(() =>
            {
                Assert.That(field, Is.Not.Null);
                Assert.That(field.FieldType, Is.EqualTo(employeeClass.MakeArrayType()));
            });
        }

        [Test]
        public void CompanyConstructorExist()
        {
            var classType = GetClass("Company");
            var employeeClass = GetClass("Employee");
            var constructor = classType.GetConstructor(new[] { employeeClass.MakeArrayType() });
            Assert.That(constructor, Is.Not.Null);
        }

        [TestCaseSource("MethodsDataAdvance")]
        public void MethodExistAdvance(string className, string methodName, Type returnType, (string, Type)[] parameters)
        {
            var classType = GetClass(className);
            var method = classType.GetMethod(methodName);
            Assert.Multiple(() =>
            {
                Assert.That(method, Is.Not.Null);
                Assert.That(method.ReturnType, Is.EqualTo(returnType));
                Assert.That(method.GetParameters()
                        .Select(x => (x.Name, x.ParameterType)).SequenceEqual(parameters),
                    Is.True);
            });
        }

        [TestCaseSource("FunctionalData")]
        public void CompanyClassFunctionalityTest(object[] employees, string maxPayHolderBeforeBonus, string maxPayHolderAfterBonus,
            decimal totalBeforeBonus, decimal totalAfterBonus)
        {
            var employeeType = GetClass("Employee");
            var companyType = GetClass("Company");
            var constructor = companyType.GetConstructor(new[] { employeeType.MakeArrayType() });
            Assert.Multiple(() =>
            {
                Assert.That(constructor, Is.Not.Null);
                var arr = Array.CreateInstance(employeeType, employees.Length);
                Array.Copy(employees, arr, employees.Length);
                var el = constructor.Invoke(new object[] { arr });
                var nameMaxSalaryMethod = companyType.GetMethod("NameMaxSalary");
                var giveEveryBodyBonusMethod = companyType.GetMethod("GiveEverybodyBonus");
                var totalToPayMethod = companyType.GetMethod("TotalToPay");
                Assert.That(nameMaxSalaryMethod, Is.Not.Null);
                Assert.That(giveEveryBodyBonusMethod, Is.Not.Null);
                Assert.That(totalToPayMethod, Is.Not.Null);

                Assert.That((string)nameMaxSalaryMethod.Invoke(el, new object[0]),
                    Is.EqualTo(maxPayHolderBeforeBonus));
                Assert.That((decimal)totalToPayMethod.Invoke(el, new object[0]),
                    Is.EqualTo(totalBeforeBonus));
                giveEveryBodyBonusMethod.Invoke(el, new object[] { (decimal)1 });
                Assert.That((decimal)totalToPayMethod.Invoke(el, new object[0]),
                    Is.EqualTo(totalAfterBonus));
                Assert.That((string)nameMaxSalaryMethod.Invoke(el, new object[0]),
                    Is.EqualTo(maxPayHolderAfterBonus));
            });
        }

        private static IEnumerable<TestCaseData> MethodsDataAdvance
        {
            get
            {
                yield return new TestCaseData("Company", "GiveEverybodyBonus", typeof(void),
                    new[] { ("companyBonus", typeof(decimal)) });
                yield return new TestCaseData("Company", "TotalToPay", typeof(decimal),
                    new (string, Type)[0]);
                yield return new TestCaseData("Company", "NameMaxSalary", typeof(string),
                    new (string, Type)[0]);
            }
        }
        
        private static IEnumerable<TestCaseData> FunctionalData
        {
            get
            {
                var employeeType = GetClass("Employee");
                var employeeConstructor = employeeType.GetConstructor(new[] { typeof(string), typeof(decimal) });
                var managerType = GetClass("Manager");
                var managerConstructor = managerType.GetConstructor(new[] { typeof(string), typeof(decimal), typeof(int) });
                var salesPersonType = GetClass("SalesPerson");
                var salesPersonConstructor = salesPersonType.GetConstructor(new[] { typeof(string), typeof(decimal), typeof(int) });
                if (employeeConstructor == null || managerConstructor == null || salesPersonConstructor == null)
                    Assert.Fail();
                yield return new TestCaseData((object)new[]
                {
                    employeeConstructor.Invoke(new object[] { "name1", (decimal)15 }),
                    employeeConstructor.Invoke(new object[] { "name2", (decimal)58 }),
                    employeeConstructor.Invoke(new object[] { "name3", (decimal)96 })
                }, "name3", "name3", (decimal)169, (decimal)172);
                yield return new TestCaseData((object)new[]
                {
                    managerConstructor.Invoke(new object[] { "name1", (decimal)1, 200 }),
                    managerConstructor.Invoke(new object[] { "name2", (decimal)45, 110 }),
                    managerConstructor.Invoke(new object[] { "name3", (decimal)69, 25 })
                }, "name3", "name1", (decimal)115, (decimal)1618);
                yield return new TestCaseData((object)new[]
                {
                    salesPersonConstructor.Invoke(new object[] { "name1", (decimal)13, 220 }),
                    salesPersonConstructor.Invoke(new object[] { "name2", (decimal)13, 110 }),
                    salesPersonConstructor.Invoke(new object[] { "name3", (decimal)14, 25 })
                }, "name3", "name1", (decimal)40, (decimal)46);
                yield return new TestCaseData((object)new[]
                {
                    employeeConstructor.Invoke(new object[] { "name1", (decimal)9 }),
                    employeeConstructor.Invoke(new object[] { "name2", (decimal)4 }),
                    employeeConstructor.Invoke(new object[] { "name3", (decimal)14 }),
                    managerConstructor.Invoke(new object[] { "name4", (decimal)14, 200 }),
                    managerConstructor.Invoke(new object[] { "name5", (decimal)14, 110 }),
                    managerConstructor.Invoke(new object[] { "name6", (decimal)14, 25 }),
                    salesPersonConstructor.Invoke(new object[] { "name7", (decimal)14, 220 }),
                    salesPersonConstructor.Invoke(new object[] { "name8", (decimal)14, 110 }),
                    salesPersonConstructor.Invoke(new object[] { "name9", (decimal)20, 25 })
                }, "name9", "name4", (decimal)117, (decimal)1629);
            }
        }
      

        #endregion

        #region Utilities

        private static Type GetClass(string className)
        {
            var classType = Type.GetType($"InheritanceTask.{className}, Inheritance");
            Assert.That(classType, Is.Not.Null);
            return classType;
        }

        #endregion
    }
}

