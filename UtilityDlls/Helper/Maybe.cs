using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public static class  Maybe
    {
        /// <summary>
        /// Возвращает обьект указанный в лямбде если он не равен null
        /// </summary>
        /// <param name="o">Объект</param>
        /// <param name="evaluator">Лямбда указывающая на другой объект</param>
        /// <returns>Объект или null</returns>
        public static TResult With<TInput, TResult>(this TInput o, Func<TInput, TResult> evaluator)
            where TResult : class
            where TInput : class
        {

            if (o == null) return null;
            return evaluator(o);

        }


        /// <summary>
        /// Возвращает указанный результат в случае если объект равен null
        /// </summary>
        /// <param name="o">Объект</param>
        /// <param name="evaluator">Лямбда указывающая на пременную</param>
        /// <param name="failureValue">значение в случае null</param>
        /// <returns></returns>
        public static TResult Return<TInput, TResult>(this TInput o,Func<TInput, TResult> evaluator, TResult failureValue) 
            where TInput : class
        {
            return o == null ? failureValue : evaluator(o);
        }

        /// <summary>
        /// Сравнение объекта с null
        /// </summary>
        /// <typeparam name="TInput">Тип входящего параметра</typeparam>
        /// <param name="o">Объект</param>
        /// <returns>результат сравнения </returns>
        public static bool ReturnSuccess<TInput>(this TInput o)
             where TInput : class
        {
            return o != null;
        }

        /// <summary>
        /// ВЫполняет сравнение если объект не равен null
        /// </summary>
        /// <param name="o">Объект</param>
        /// <param name="evaluator">Функция сравнения</param>
        /// <returns>Результат функции сравнения если объект не равне null,иначе null</returns>
        public static TInput If<TInput>(this TInput o, Func<TInput, bool> evaluator)
        where TInput : class
        {
            if (o == null) return null;
            return evaluator(o) ? o : null;
        }

        /// <summary>
        /// ВЫполняет сравнение если объект не равен null
        /// </summary>
        /// <param name="o">Объект</param>
        /// <param name="evaluator">Функция сравнения</param>
        /// <returns>Результат функции сравнения если объект не равне null,иначе null</returns>
        //public static TInput Unless<TInput>(this TInput o, Func<TInput, bool> evaluator)
        //where TInput : class
        //{
        //    if (o == null) return null;
        //    return evaluator(o) ? null : o;
        //}

        /// <summary>
        /// Выполнит действие если объект не равен null
        /// </summary>
        /// <param name="o">Объект</param>
        /// <param name="action">действие</param>
        /// <returns></returns>
        public static TInput Do<TInput>(this TInput o, Action<TInput> action)
        where TInput : class
        {
            if (o == null) return null;
            action(o);
            return o;
        }

    }



    //************************
    //Пример использования
    //************************




    //public class Person
    //{
    //    public Address Address { get; set; }
    //}

    //public class Address
    //{
    //    public House House { get; set; }
    //}

    //public class House  
    //{
    //    public string Parametr { get; set; }
    //}


    //class MyClass
    //{
    //    public MyClass(Person person)
    //    {
    //        //adress = person.Adress если person.Adress!=null
    //        // adress = null если person.Adress==null
    //        Address address = person.With(p => p.Address);

    //        // parametr = person......Parametr если вся цепочка не равно null
    //        // parametr = string.Empty если хотя бы один элемент из цепочки равен null
    //        string parametr = person.With(p => p.Address)
    //                                .With(p => p.House)
    //                                .Return(p => p.Parametr, string.Empty);

    //        //returnSuccess = true если person (или цепочка ) != null
    //        // иначе false
    //        bool returnSuccess = person.ReturnSuccess();

    //        //house = house если цепочка не ровна null и выполняется условие
    //        //иначе null
    //        House house = person.With(p => p.Address)
    //                            .With(p => p.House)
    //                            .If(p => p.Parametr.Length > 3);

    //        //house = house если цепочка не ровна null и НЕ выполняется условие
    //        //иначе null
    //        House house2 = person.With(p => p.Address)
    //                           .With(p => p.House)
    //                           .Unless(p => p.Parametr.Length > 3);

    //        // если person не равно null выполнит действие и вернет person
    //        //иначе вернет null
    //        Person doing = person.Do(p => p = new Person());
    //    }
    //}


}
