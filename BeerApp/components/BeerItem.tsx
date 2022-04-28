import { Text, Image, View, StyleSheet } from "react-native";
import Beer from "../services/beer.model";

export type BeerItemProps = {
  beer: Beer,
};

const BeerItem = (props: BeerItemProps) => {

  const beer = props;

  return (
    <View style={{flexDirection: 'column'}}>
    <View style={styles.container}>
      <View style={styles.leftContainer}>
        <Text style={styles.title}>{props.beer.title}</Text>
        <Text style={styles.price}>{props.beer.price} €</Text>
      </View>
      <View style={styles.rightContainer}>
        <Text style={styles.category}>{props.beer.category}</Text>
        <Text style={styles.size}> {props.beer.size} cl</Text>
      </View>
    </View>
    <View style={styles.barre}/>
    </View>
  );
};

export default BeerItem;

const styles = StyleSheet.create({
  title: {
    color: 'black',
    fontSize: 20,
    fontWeight: 'bold'
},
price: {
    color: 'black',
    fontSize: 16,
}, 
category:{
  fontSize: 16, 
  
},
size : {
  fontSize: 16,
},

leftContainer: {
  justifyContent: 'space-around',
  

},

rightContainer: {

    justifyContent: 'space-around',
    alignItems: "flex-end",
    

},
container: {
  flex: 1,
  flexDirection:'row',
  paddingVertical: 10,

  justifyContent: 'space-between',
 
},
barre:{
  width: '100%',
  height: 1,
  backgroundColor: 'lightgray',
}

})
