export default class Beer {
   
  
    // a property with the same name is automatically associated to each public argument
    constructor(
        
      public beerId: string,
      public title: string,
      public category: string,
      public price: number,
      public alccolDegree: number,
      public size: number,
      public imageUri : string,
        
    ) {}
  }