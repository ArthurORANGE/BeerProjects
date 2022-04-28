import Beer from "../services/beer.model";
import BeerItem from "../components/BeerItem";

const rootEndpoint = "https://ensc2022beer.azurewebsites.net/api";

// Beer data fields, as returned by the API
interface BeerData {
  title: string;
  // JSON dates are actually strings, not JavaScript dates
  // Example : "1984-03-13T00:00:00"
  beerId: string,
  category: string;
  price: number;
  alcoolDegree: number;
  size: number;
  image : string,
}

class BeerService {
  // Retrieve all Beers
  getAll(): Promise<Array<Beer>> {
    // Fetch API for all Beers, then transform the returned JSON data
    return fetch(rootEndpoint + "/ApiBeer").then((response) =>
      response.json().then((beersData) => this.createBeers(beersData))
    );
  }

  // Convert an array of JSON data to an array  of Beer objects
  private createBeers(beersData: Array<BeerData>): Array<Beer> {
    // Apply the same function to each element of the array
    return beersData.map((beerData) => this.createBeer(beerData));
  }

  // Convert JSON data for a Beer into a Beer object
  private createBeer(beerData: BeerData): Beer {
    return new Beer(
      beerData.beerId,
      beerData.title,
      beerData.category,
      beerData.price,
      beerData.alcoolDegree,
      beerData.size,
      beerData.image,
    );
  }
}

export default new BeerService();