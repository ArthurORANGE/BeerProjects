import React, { Component } from "react";
import { StyleSheet, View } from "react-native";
import BeerList from "../components/BeerList";
import Beer from "../services/beer.model";
import beerService from "../services/beer.services";  

interface BeerScreenState {
  beers: Array<Beer>;
}

export default class BeerScreen extends Component<{}, BeerScreenState> {
  state: BeerScreenState = {
    beers: [],
  };

  loadBeers = () => {
    // Load all beers
    beerService.getAll().then((beers) => {
      this.setState({ beers });
    });
  };

  componentDidMount() {
    // Trigger Beer loading as soon as component is ready
    this.loadBeers();
  }

  render() {
    return (
      <View style={styles.container}>
          <BeerList beers={this.state.beers} />
      </View>
    );
  }
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
  },
});