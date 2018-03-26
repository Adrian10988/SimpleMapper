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
- 1.1.1 - More unit test coverage
- 1.2.0 - Use of dependency injection within the project
