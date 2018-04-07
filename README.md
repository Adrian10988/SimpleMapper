# Breaking Changes coming soon
Version 2.0 will see a change in the foundation of the attributes system. Currently attributes are placed on the class that *needs to be mapped*. This confines you to a one to one mapping relationship. Take for example:  
  
	[RequireAllProperties]
	public class Foo : IMappable<Foo, Bar>
	{
		public string Name{get;set;}
		public int Age {get; set;}
	}

	public class Bar
	{
		public string Name {get; set;}
		public int Age {get; set;}
	}

	public class HalfBar
	{
		public string Name {get; set;}
	}
	
In the above case, `Foo` is now tied to `Bar` and you may never be able to map a `Foo` to a `HalfBar`. Even if you could have multiple associations, `Foo` requires all properties to match and thus `HalfBar` would be an invalid mapping target. 

In Version 2.0 the mapping attributes will move over to the mapping *result* class. This opens up the possibility of having a one to many relationship between mappings. We can have one view model tied to many domain models or one domain model tied to many view models. This should be enough to work with as we should be defining very specific models. Many to many relationships would make it too easy to start mixing responsibilities within models. This is how the new system will work: 

	public class Foo 
		public string Name{get;set;}
		public int Age {get; set;}
	}

	[RequireAllProperties]
	public class Bar : IMappable<Foo, Bar> //Foo is the class that will be mapped to Bar
	{
		public string Name {get; set;}
		public int Age {get; set;}
	}

	//Do not require all properties, if we did, HalfBar would blow up
	public class HalfBar : IMappable<Foo, HalfBar> //Foo is the class that will be mapped to HalfBar
	{
		public string Name {get; set;}
	}
	
	
As you can see above, `Foo` now can be tied to many classes, those being `Bar` and `HalfBar`

# SimpleMapper
Stupid simple attribute based mapping for C#

# Examples

Consider the following two classes
  
    //Notice the inheritance here. <From, To>
    public class FooValueObject : BaseMappable<FooValueObject, FooViewModel>
    {
	    public string FooName {get; set;}
      public int FooAge {get; set;}
      public bool FooIsCool {get; set;}
      public string FoosPassword {get; set;}
    }



    //We are only interested in identifiable info, not password... obviously
    public class FooViewModel
    {
      public string FooName {get; set;}
      public string FooAge {get; set;}
      public bool FooIsCool {get; set;}
    }

Now lets see how we actually map data  
  
    
        public void MapTheFoo()
        {
          var myFoo = new FooValueObject()
          {
            FooName = "Dhruv",
            FooAge = 30,
            FooIsCool = true //false?
          };

          //done
          var fooViewModel = myFoo.Map(myFoo);
        }  
          
Now I know what you are thinking.. How do I do more complex mapping? Just implement `IMappable` like this..  
  
    public class FooValueObject : IMappable<FooValueObject, FooViewModel>
    {
	    public string FooName {get; set;}
	    public int FooAge {get; set;}
	    public bool FooIsCool {get; set;}
	    public string FoosPassword {get; set;}
	
	    public FooViewModel Map(FooValueObject mapTarget)
	    {
		    //complex stuff goes here
	    }
    }  
    
# Attributes
- `[Bypass]` is property level and will signal SimpleMapper to skip this property during mapping
- `[ImplicitlyConvertPrimitives]` is class level and will tell SimpleMapper to convert between strings and numeric types
- `[RejectNullReferences]` is class *and* property level. It will tell SimpleMapper to throw `NullReferenceExceptions` should it encounter a null reference at the class or property level.
- `[RequireAllProperties]` is class level and will tell SimpleMapper to double check that both mapping classes have the same exact properties. If class A has property 1 but Class B does not have property 1, SimpleMapper will throw an exception.
- `[MapTp]` is property level and allows you to explicitly name the property on the mapping target. This allows you to map properties with different names. If no property is found, the mapping will not take place.

# Pre Runtime validation
`Validator.ValidateMappings` will take a list of `Assembly` types and will extract all classes that inherit from `BaseMappable` and run pre-runtime checks on them to make sure you can unit test your mappings. Make sure to create a unit test using this method.
      
# Important Gotchas!
- SimpleMapper is only focused on mapping DTOs. As such it only works mapping the following primitives `bool`, `string`, `int`, `long`, `decimal`, `double`. It will ignore reference types. If you need to map nested types, map them separately then aggregate them yourself.
- SimpleMapper only tries to map what it can by default. This means it will skip over properties that are not present on the destination type. This can be overridden by applying the `[RequireAllProperties]` attribute at the class level.


# Road Map
2.0.0 :
- Changing mechanics for underlying attributes and mapping system
- Adding `DateTime` and `TimeSpan` to mappable properties
- Simplifying the `IMappable` interface to take only one generic argument
