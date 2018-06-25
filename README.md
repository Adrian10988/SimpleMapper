[![Build Status](https://travis-ci.org/AaronLenoir/flaclibsharp.svg?branch=master)](https://travis-ci.org/Adrian10988/SimpleMapper)
# Version 2.2.0 is here


# Quick Start
## Default Mapping
    public class Order
    {
      public string Id {get; set;}
      public DateTime PlacementDate {get; set;}
      public bool IsGift {get; set;}
    }

    public class PendingOrder : BaseMappable<Order, PendingOrder>
    {
      public string Id {get; set;}
      public string Status {get; set;}
      public bool IsGift {get; set;}
      public DateTime PlacementDate {get; set;}
    }

    public void PerformTheMapping()
    {
      var order = _orderRepo.Get("A124B2");
      var mapSlave = new PendingOrder();
      //`mappedEntity` is of type `PendingOrder`
      var mappedEntity = mapSlave.Map(order);
    }
    
From the above example, we can see that the mapping attributes go on the *result* class and not the *source* class. We can also see that `PendingOrder` contains property: `Status` which `Order` does not. By default, _SimpleMapper_ only maps common properties. This can be overriden with the `RequireAllPropertiesAttribute`. See below for an example

## Using RequireAllPropertiesAttribute
    public class Cat 
    {
      public string Breed {get; set;}
      public double Weight {get; set;}
    }

    [RequireAllProperties]
    public class WildCat : BaseMappable<Cat, WildCat>
    {
      public string Breed {get; set;}
      public string Weight {get; set;}
      public string Region {get; set;}
    }
    
 When performing a call to `Map` on `WildCat` a `MissingMemberException` will be thrown. 
    
    
