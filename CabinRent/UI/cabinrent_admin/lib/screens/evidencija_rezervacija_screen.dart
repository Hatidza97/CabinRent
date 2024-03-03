import 'dart:convert';
import 'dart:ffi';
import 'dart:typed_data';

import 'package:cabinrent_admin/models/pictures.dart';
import 'package:cabinrent_admin/models/product.dart';
import 'package:cabinrent_admin/models/rezervacija.dart';
import 'package:cabinrent_admin/models/search_result.dart';
import 'package:cabinrent_admin/providers/pictures_provider.dart';
import 'package:cabinrent_admin/providers/product_provider.dart';
import 'package:cabinrent_admin/providers/rezervacija_provider.dart';
import 'package:cabinrent_admin/screens/product_detail_screen.dart';
import 'package:cabinrent_admin/utils/util.dart';
import 'package:cabinrent_admin/widgets/master_screen.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';

class EvidencijaRezervacijaScreen extends StatefulWidget {
  Objekat? objekat;

  EvidencijaRezervacijaScreen({Key? key, this.objekat}) : super(key: key);

  @override
  State<EvidencijaRezervacijaScreen> createState() => _EvidencijaRezervacijaScreenState();
}

class _EvidencijaRezervacijaScreenState extends State<EvidencijaRezervacijaScreen> {
  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};

  late ProductProvider _productProvider;
  late PicturesProvider _picturesProvider;
  late RezervacijaProvider _rezervacijaProvider;
  List<DateTime> dateList = [];
  DateTime? _selectedPrijaveDate;
  DateTime? _selectedOdjaveDate;
  @override
  void initState() {
    super.initState();
    _initialValue = {
      'naziv': widget.objekat?.naziv,
      'povrsina': widget.objekat?.povrsina,
      'brojMjestaDjeca': widget.objekat?.brojMjestaDjeca.toString(),
      'brojMjestaOdrasli': widget.objekat?.brojMjestaOdrasli.toString(),
      'brojMjestaUkupno': widget.objekat?.brojMjestaUkupno.toString(),
      'opis': widget.objekat?.opis,
      'rezervisan': widget.objekat?.rezervisan,
      'gradId': widget.objekat?.gradId.toString()
    };
  }

  void didChangeDependencies() {
    super.didChangeDependencies();
    _productProvider = context.read<ProductProvider>();
    _picturesProvider = context.read<PicturesProvider>();
    _rezervacijaProvider = context.read<RezervacijaProvider>();
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      title: 'Rezervacija',
      child: Container(
        child: Column(children: [
          Text("REZERVACIJA"),
        ]),
      ),
    );
  }
  
 
}
