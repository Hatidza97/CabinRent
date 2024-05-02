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

  SeearchResult<Rezervacija>? resultReservations;

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
          Padding(
              padding: EdgeInsets.all(10),
              child: Row(
                children: [
                  _buildSearchRezervacija(),
                ],
              ),
            ),
             Expanded(
              child: _buildDataListView(),
            ),
             Expanded(
              child: _buildMostReservedObjekat(),
            ),
        ]),
      ),
    );
  }

 int? mostReservedObjekat;
Widget _buildMostReservedObjekat() {
  return Padding(
    padding: EdgeInsets.all(10),
    child: Column( // Wrap in Column to accommodate multiple children
      children: [
        ElevatedButton(
          onPressed: () {
            if (resultReservations != null && resultReservations!.result.isNotEmpty) {
              // Map to count occurrences of ObjekatId
              Map<int, int> objekatCount = {};
              resultReservations?.result.forEach((reservation) {
                int objekatId = reservation.objekatId!; // Assuming property name is objekatId
                objekatCount[objekatId] = (objekatCount[objekatId] ?? 0) + 1;
              });
              // Find the ObjekatId with the maximum count
              int mostReservedObjekatId = objekatCount.entries.fold(
                objekatCount.keys.first, // Initialize with the first key
                (prev, entry) {
                  if (entry.value > objekatCount[prev]!) {
                    return entry.key;
                  } else {
                    return prev;
                  }
                }
              );
              // Update UI with the most reserved ObjekatId
              setState(() {
                mostReservedObjekat = mostReservedObjekatId;
              });
            }
          },
          child: const Text('Pronadji objekat sa najviše rezervacija'),
        ),
        SizedBox(height: 20), // Add some space between button and text
        if (mostReservedObjekat != null)
          Text(
            'Objekat sa najviše rezervacija (ID): $mostReservedObjekat',
            style: TextStyle(fontSize: 16),
          ),
      ],
    ),
  );
}

  Widget _buildSearchRezervacija() {
    return Padding(
      padding: EdgeInsets.all(10),
      child: ElevatedButton(
        onPressed: () async {
          var data = await _rezervacijaProvider.get();
          setState(() {
            resultReservations = data;
          });
        },
        child: const Text('Ucitaj sve rezervacije'),
      ),
    );
  }
  

  String formatDate(DateTime dateTime) {
  // Convert DateTime to local timezone
  dateTime = dateTime.toLocal();
  // Get the ISO 8601 string representation of the DateTime
  String isoString = dateTime.toIso8601String();
  // Extract just the date part (YYYY-MM-DD)
  String date = isoString.split('T')[0];
  return date;
}

  Widget _buildDataListView() {
    return SingleChildScrollView(
      child: Padding(
        padding: const EdgeInsets.all(10.0),
        child: DataTable(
          columns: const [
            DataColumn(
              label: Text(
                "ID",
                style: TextStyle(fontStyle: FontStyle.italic),
              ),
            ),
            DataColumn(
              label: Text(
                "Datum prijave",
                style: TextStyle(fontStyle: FontStyle.italic),
              ),
            ),
            DataColumn(
              label: Text(
                "Datum odjave",
                style: TextStyle(fontStyle: FontStyle.italic),
              ),
            ),
            DataColumn(
              label: Text(
                "Broj djece",
                style: TextStyle(fontStyle: FontStyle.italic),
              ),
            ),
            DataColumn(
              label: Text(
                "Broj odraslih",
                style: TextStyle(fontStyle: FontStyle.italic),
              ),
            ),
              DataColumn(
              label: Text(
                "Rezervisani objekat (ID)",
                style: TextStyle(fontStyle: FontStyle.italic),
              ),
            ),
              DataColumn(
              label: Text(
                "Otkazano",
                style: TextStyle(fontStyle: FontStyle.italic),
              ),
            )
          ],
          rows: resultReservations?.result
                  .map(
                    (Rezervacija e) => DataRow(
                      onSelectChanged: (selected) {
                        setState(() {
                        });
                      },
                      cells: [
                        DataCell(Text(e.rezervacijaId.toString() ?? "")),
                        DataCell(Text(e.datumPrijave?.split('T')[0] ?? "")),
                        DataCell(Text(e.datumOdjave?.split('T')[0] ?? "")),
                        DataCell(Text(e.brojDjece.toString() ?? "")),
                        DataCell(Text(e.brojOdraslih.toString() ?? "")),
                        DataCell(Text(e.objekatId.toString() ?? "")),
                        DataCell(Text(e.otkazano.toString()=='false'?'Nije otkazano':'Otkazano' ?? "")),
                      
                      ],
                    ),
                  )
                  .toList() ??
              [],
        ),
      ),
    );
  }
 
}
