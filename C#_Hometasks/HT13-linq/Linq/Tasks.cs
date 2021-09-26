using System;
using System.Collections.Generic;
using System.Linq;
using Linq.Objects;

namespace Linq
{
    public static class Tasks
    {
        //The implementation of your tasks should look like this:
        public static string TaskExample(IEnumerable<string> stringList)
        {
            return stringList.Aggregate<string>((x, y) => x + y);
        }

        #region Low

        public static IEnumerable<string> Task1(char c, IEnumerable<string> stringList)
        {
            return stringList.Where(word => word.StartsWith(c) && word.EndsWith(c) && word.Length > 1);
        }

        public static IEnumerable<int> Task2(IEnumerable<string> stringList)
        {
            return stringList.Select(word => word.Length).OrderBy(length => length);
        }

        public static IEnumerable<string> Task3(IEnumerable<string> stringList)
        {
            return stringList.Select(word => $"{word[0]}{word[word.Length - 1]}");
        }

        public static IEnumerable<string> Task4(int k, IEnumerable<string> stringList)
        {
            return stringList.Where(word => word.Length == k && char.IsNumber(word[word.Length - 1])).OrderBy(number => number);
        }

        public static IEnumerable<string> Task5(IEnumerable<int> integerList)
        {
            return integerList.Where(number => number % 2 != 0).OrderBy(number => number).Select(number => number.ToString());
        }

        #endregion

        #region Middle

        public static IEnumerable<string> Task6(IEnumerable<int> numbers, IEnumerable<string> stringList)
        {
            return numbers.Select(n => stringList.FirstOrDefault(word => char.IsNumber(word[0]) && word.Length == n) ?? "Not found"); 
        }

        public static IEnumerable<int> Task7(int k, IEnumerable<int> integerList)
        {
            return integerList.Where(n => n % 2 == 0).Except(integerList.Skip(k)).Reverse();
        }

        public static IEnumerable<int> Task8(int k, int d, IEnumerable<int> integerList)
        {
            return integerList.TakeWhile(n => n <= d).Union(integerList.Skip(k)).OrderByDescending(n => n);
        }

        public static IEnumerable<string> Task9(IEnumerable<string> stringList)
        {
            return stringList
                .Select(str => 
                new 
                { 
                    Sum = stringList.Where(st => st.StartsWith(str[0])).Sum(r => r.Length), 
                    Symbol = str.First()
                })
                .OrderByDescending(r => r.Sum)
                .ThenBy(r => r.Symbol)
                .Select(r => $"{r.Sum}-{r.Symbol}")
                .Distinct();
        }

        public static IEnumerable<string> Task10(IEnumerable<string> stringList)
        {
            return stringList
                .OrderBy(s => s)
                .GroupBy(n => n.Length)
                .Select(s => stringList.Where(r => r.Length == s.Key).OrderBy(g => g))
                .Select(m => string.Concat(m
                    .Select(str => char.ToUpper(str.Last()))))
                .OrderByDescending(s => s.Length);
        }

        #endregion

        #region Advance

        public static IEnumerable<YearSchoolStat> Task11(IEnumerable<Entrant> nameList)
        {
            return nameList.GroupBy(year => year.Year).Select(s => new YearSchoolStat { Year = s.Key, NumberOfSchools = s.GroupBy(entrant => entrant.SchoolNumber).Count() }).OrderBy(n => n.NumberOfSchools).ThenBy(n => n.Year);
        }

        public static IEnumerable<NumberPair> Task12(IEnumerable<int> integerList1, IEnumerable<int> integerList2)
        {
            return integerList1.SelectMany(n => integerList2.Where(m => n % 10 == m % 10).Select(s => new NumberPair { Item1 = n, Item2 = s})).OrderBy(n => n.Item1).ThenBy(n => n.Item2);
        }

        public static IEnumerable<YearSchoolStat> Task13(IEnumerable<Entrant> nameList, IEnumerable<int> yearList)
        {
            return yearList.Select(year => new YearSchoolStat { Year = year, NumberOfSchools = nameList.GroupBy(entrant => entrant.Year).FirstOrDefault(n => n.Key == year)?.Select(entrant => entrant.SchoolNumber).Distinct().Count() ?? 0 }).OrderBy(n => n.NumberOfSchools).ThenBy(n => n.Year);
        }

        public static IEnumerable<MaxDiscountOwner> Task14(IEnumerable<Supplier> supplierList,
                IEnumerable<SupplierDiscount> supplierDiscountList)
        {
            return supplierDiscountList.GroupBy(sd => sd.ShopName).Select(group =>
            {
                var discount = group.Max(sd => sd.Discount);
                var customerId = group.Where(sd => sd.Discount == discount).Min(sd => sd.SupplierId);
                var customer = supplierList.FirstOrDefault(customer => customer.Id == customerId);
                return new MaxDiscountOwner { ShopName = group.Key, Discount = discount, Owner = customer };
            }).OrderBy(maxDisountOwner => maxDisountOwner.ShopName);
        }

        public static IEnumerable<CountryStat> Task15(IEnumerable<Good> goodList,
            IEnumerable<StorePrice> storePriceList)
        {
            return goodList.GroupBy(good => good.Country).Select(group =>
            {
                var stores = group.SelectMany(good => storePriceList.Where(price => price.GoodId == good.Id)).GroupBy(shop => shop.Shop).Select(shopGroup => shopGroup.First());
                var anyStores = stores.Any();
                var storeNumber = anyStores ? stores.Count() : 0;
                var minPrice = anyStores ? stores.Select(store => store.Price).Min() : 0;
                return new CountryStat { Country = group.Key, StoresNumber = storeNumber, MinPrice = minPrice };
            }).OrderBy(countryStat => countryStat.Country);
        }

        #endregion

    }
}
