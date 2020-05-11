[![Build Status](https://travis-ci.org/AaronLenoir/flaclibsharp.svg?branch=master)](https://travis-ci.org/Adrian10988/SimpleMapper)
# Version 3 is here


# Quick Start
## Default Mapping
    [MapDestination(typeof(PendingOrder))]
    public class Order
    {
      public string Id {get; set;}
      public DateTime PlacementDate {get; set;}
      public bool IsGift {get; set;}
    }

    public class PendingOrder
    {
      public string Id {get; set;}
      public string Status {get; set;}
      public bool IsGift {get; set;}
      public DateTime PlacementDate {get; set;}
    }

    public void PerformTheMapping()
    {
      var order = _orderRepo.Get("A124B2");
      var pendingOrder = SimpleMapper.Mapper.Copy<Order, PendingOrder>(order);
    }

## Using RequireAllPropertiesAttribute
    [MapDestination(typeof(WildCat))]
    public class Cat 
    {
      public string Breed {get; set;}
      public double Weight {get; set;}
    }

    [RequireAllProperties]
    public class WildCat
    {
      public string Breed {get; set;}
      public string Weight {get; set;}
      public string Region {get; set;}
    }
    
 When performing a call to `Map` on `WildCat` a `MissingMemberException` will be thrown. 
    
    
