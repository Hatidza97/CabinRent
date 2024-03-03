import 'package:cabinrent_admin/main.dart';
import 'package:cabinrent_admin/screens/evidencija_izdavaca_screen.dart';
import 'package:cabinrent_admin/screens/evidencija_rezervacija_screen.dart';
import 'package:cabinrent_admin/screens/product_detail_screen.dart';
import 'package:cabinrent_admin/screens/product_list_screen.dart';
import 'package:cabinrent_admin/screens/rezervacija_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';

class MasterScreenWidget extends StatefulWidget {
  Widget? child;
  String? title;
  MasterScreenWidget({this.child, this.title, Key? key}) : super(key: key);

  @override
  State<MasterScreenWidget> createState() => _MasterScreenWidgetState();
}

class _MasterScreenWidgetState extends State<MasterScreenWidget> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(widget.title ?? ""),
      ),
      drawer: Drawer(
          child: ListView(
        children: [
          ListTile(
            title: Text("Back"),
            onTap: () {
              Navigator.of(context).pop();
            },
          ),
          ListTile(
            title: Text("Login page"),
            onTap: () {
              Navigator.of(context).push(MaterialPageRoute(
                  builder: (context) => LoginPage()));
            },
          ),
          ListTile(
            title: Text("Objekti"),
            onTap: () {
              Navigator.of(context).push(MaterialPageRoute(
                  builder: (context) => const ProductListScreen()));
            },
          ),
          ListTile(
            title: Text("Detalji"),
            onTap: () {
              Navigator.of(context).push(MaterialPageRoute(
                  builder: (context) => ProducDetailScreen()));
            },
          ),
          ListTile(
            title: Text("Evidencija izdavača"),
            onTap: () {
              Navigator.of(context).push(MaterialPageRoute(
                  builder: (context) => IzdavacListScreen()));
            },
          ),
           ListTile(
            title: Text("Evidencija rezervacija"),
            onTap: () {
              Navigator.of(context).push(MaterialPageRoute(
                  builder: (context) => EvidencijaRezervacijaScreen()));
            },
          )
        ],
      )),
      body: widget.child!,
    );
  }
}
