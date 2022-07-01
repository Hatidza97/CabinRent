import 'package:firstapp/screens/objects/object_screen.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'cabinrent_drawer.dart';

class MasterScreenWidget extends StatefulWidget{
  Widget? child;
  MasterScreenWidget({this.child,Key?key}):super(key: key);
  @override
  State<MasterScreenWidget>createState()=>_MasterScreenWidgetState();
}
class _MasterScreenWidgetState extends State<MasterScreenWidget>{
  int currentIndex=0;
  void _onItemTapped(int index){
    setState(() {
      currentIndex=index;
    });
    if(currentIndex==0){
      Navigator.pushNamed(context, ObjectListScreen.routeName);
    }
    }
    @override
    Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(),
      drawer: cabinrent(),
      body: SafeArea(
        child: widget.child!,
      ),
      bottomNavigationBar: BottomNavigationBar(
        items: const <BottomNavigationBarItem>[
          BottomNavigationBarItem(
            icon: Icon(Icons.home),
            label: 'Home',
            
          ),
          BottomNavigationBarItem(
            icon: Icon(Icons.shopping_bag),
            label: 'Cart',
          ),
          
        ],
        
        selectedItemColor: Colors.amber[800],
        currentIndex: currentIndex,
        onTap: _onItemTapped,
      ),
    );
}
} 