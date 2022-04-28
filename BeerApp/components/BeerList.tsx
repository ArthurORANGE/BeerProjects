import React, { Component } from "react";
import { Text } from "react-native";
import { StyleSheet, FlatList } from "react-native";
import Beer from "../services/beer.model";
import BeerItem from "../components/BeerItem";

// import {Beer} from "../types";

export type BeerListProps = {
  beers: Array<Beer>;
}

export default class BeerList extends Component<BeerListProps, {}> {
  render() {
    return (
      <FlatList<Beer>
        style={styles.container}
        data={this.props.beers}
        renderItem ={({item}) => <BeerItem beer={item}/>}
        keyExtractor= {(beer) => beer.beerId }
      />
      
    
);
    }}

{/* {item.title}  */}
const styles = StyleSheet.create({
  container: {
    flex: 1,
    marginHorizontal: 10,
  },
});