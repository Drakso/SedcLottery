using System;

namespace Lottery.Mapper
{
    #region Reflection Explanation
    /* Reflection is the ability for us to see and extract data from our code
     * With Reflection we can find details for an object, class, methods, create objects and call methods on runtime
     * Basically we can peek in to the implementation of anything in our code and use that data if needed
     * Reflection can see all the code including private fields and classes       
     */
    #endregion
    // This is the mapper class. It is static because we want the map function to be an extension method
    // This mapper will have one job. To convert from one model to another based on the properties names
    // If the names are the same it will map them
    public static class Mapper
    {
        // This is the mapper extension method. It is a generic method that takes 2 types, T1 and T2
        // T1 is the original object type and T2 is the object type in which we want to convert to ( We convert from T1 into T2 )
        public static T2 Map<T1, T2>(this T1 dbModel) // the "this" comes from extension methods and means that it will be executed on the model as method. EX: award.Map<Award, AwardModel>();
        {
            // This CreateInstance is a method that can create instances out of strings, objects or generic types
            // Because we don't know what type T2 is, and can't new T2() we create instance using the CreateInstance method
            var model = Activator.CreateInstance<T2>();

            // Now we get the type from the dbModel and use the GetProperties() reflection method to get all properties from that type
            // At this point propertyInfo is information about one property out of the dbModel class ( T1 )
            foreach (var propertyInfo in dbModel.GetType().GetProperties())
            {
                // Here we try and find a property from the output type ( T2 ) with that name of the input ( T1 ) property
                var property = model.GetType().GetProperty(propertyInfo.Name);

                // If there is such a property then execute the mapping
                if (property != null)
                {
                    // Here we get the property value from T1 and add it to a variable with the reflection method GetValue
                    var propertyValue = propertyInfo.GetValue(dbModel, null); // the null means that the property is not an indexed property ( EX: Array )
                    // Here we check for types that we can immediately match ( Not objects )
                    if (propertyValue is string || propertyValue is DateTime)
                    {
                        // We add the property that we created earlier to the output model ( T2 ) and add the value
                        property.SetValue(model, propertyValue);
                    }
                    // If the property is not string or DateTime it might be a complex model like an object
                    // That is why we will try and call the mapper again and map the object with its properties
                    else
                    {
                        // t1 will now be the property object of T1 input
                        var t1 = propertyValue.GetType();
                        // t2 will be the type of the T2 object property
                        var t2 = property.GetValue(model, null).GetType();
                        // This is an example of using reflections for getting method data
                        // With the reflection method GetMethod we get the Map method from Mapper class
                        var method = typeof(Mapper).GetMethod("Map");

                        if (method != null)
                        {
                            // Here we construct the method with the types given for T1 and T2 types
                            var generic = method.MakeGenericMethod(t1, t2);
                            // And finaly with the reflection method Invoke we invoke the method we constructed
                            // propertyValue is the object on which the method will be executed
                            var result = generic.Invoke(null, new[] { propertyValue });
                            // Here we set the mapped property object to the output ( T2 ) model
                            property.SetValue(model, result);
                        }
                    }
                }
            }
            return model;
        }
    }
}
