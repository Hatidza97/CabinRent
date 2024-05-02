import 'package:cabinrent_admin/models/rezervacija.dart';
import 'package:cabinrent_admin/models/search_result.dart';
import 'package:cabinrent_admin/providers/product_provider.dart';
import 'package:cabinrent_admin/providers/rezervacija_provider.dart';
import 'package:cabinrent_admin/providers/tip_objekta_provider.dart';
import 'package:cabinrent_admin/widgets/master_screen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class IzvjestajScreen extends StatefulWidget {
  IzvjestajScreen({Key? key}) : super(key: key);

  @override
  State<IzvjestajScreen> createState() => _IzvjestajScreenState();
}

class _IzvjestajScreenState extends State<IzvjestajScreen> {
  SeearchResult<Rezervacija>? resultReservations;
  late RezervacijaProvider _rezervacijaProvider;
  late ProductProvider _objekatProvider;
  late TipObjektaProvider _tipObjektaProvider;
  int? mostReservedObjekat;
  var objekatData;
  var tipObjektaData;

  @override
  void initState() {
    super.initState();
    _rezervacijaProvider = context.read<RezervacijaProvider>();
    _objekatProvider = context.read<ProductProvider>();
    _tipObjektaProvider = context.read<TipObjektaProvider>();
    _fetchData();
  }

  Future<void> _fetchData() async {
    var data = await _rezervacijaProvider.get();
    setState(() {
      resultReservations = data;
    });

    if (resultReservations != null && resultReservations!.result.isNotEmpty) {
      // Map to count occurrences of ObjekatId
      Map<int, int> objekatCount = {};
      resultReservations?.result.forEach((reservation) {
        int objekatId = reservation.objekatId!;
        // Assuming property name is objekatId
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
        },
      );
      // Update UI with the most reserved ObjekatId
      setState(() {
        mostReservedObjekat = mostReservedObjekatId;
      });

      // Fetch data for the most reserved object
      if (mostReservedObjekat != null) {
        // Call provider to get data for mostReservedObjekat
        objekatData = await _objekatProvider.get(filter: {'objekatId': mostReservedObjekatId});
        // Do something with objekatData, such as updating UI
        print('Data for most reserved Objekat: $objekatData');
        setState(() {}); // Trigger rebuild after getting objekatData
      }
    }
  }

  Widget build(BuildContext context) {
    return MasterScreenWidget(
      title: 'Izvjestaj',
      child: Container(
        padding: EdgeInsets.all(10),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Text(
              "Izvjestaj",
              style: TextStyle(fontSize: 24, fontWeight: FontWeight.bold),
            ),
            SizedBox(height: 20),
            if (mostReservedObjekat != null) ...[
              _buildObjekatDataView(),
            SizedBox(height: 20),
              _buildTipObjektaDataView(),
            ],
          ],
        ),
      ),
    );
  }

  Widget _buildObjekatDataView() {
    // Check if objekatData is not null and contains results
    if (objekatData != null && objekatData!.result.isNotEmpty) {
      // Assuming objekatData contains a list of objects, and you want to display details of the first object
      var mostReservedObjekatData = objekatData!.result[0];
      return Container(
        padding: EdgeInsets.all(10),
        decoration: BoxDecoration(
          border: Border.all(color: Colors.grey),
          borderRadius: BorderRadius.circular(10),
        ),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Text(
              'Detalji najviše rezervisanog objekta:',
              style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold),
            ),
            SizedBox(height: 10),
            Text(
              'Naziv: ${mostReservedObjekatData.naziv}',
              style: TextStyle(fontSize: 16),
            ),
            Text(
              'Opis: ${mostReservedObjekatData.opis}',
              style: TextStyle(fontSize: 16),
            )
          ],
        ),
      );
    } else {
      // Handle the case when objekatData is null or empty
      return Container(
        padding: EdgeInsets.all(10),
        child: Text(
          'Nema dostupnih podataka za najviše rezervisan objekat.',
          style: TextStyle(fontSize: 16),
        ),
      );
    }
  }

Widget _buildTipObjektaDataView() {
  return FutureBuilder<void>(
    future: _buildTipObjektaData(),
    builder: (context, snapshot) {
     if (snapshot.hasError) {
        return Text('Error: ${snapshot.error}');
      } else {
        if (tipObjektaData != null && tipObjektaData.result.isNotEmpty) {
          var firstTipObjektum = tipObjektaData.result[0];
          return Container(
            padding: EdgeInsets.all(10),
            decoration: BoxDecoration(
              border: Border.all(color: Colors.grey),
              borderRadius: BorderRadius.circular(10),
            ),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text(
                  'Detalji tipa objekta:',
                  style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold),
                ),
                SizedBox(height: 10),
                Text(
                  'Tip: ${firstTipObjektum.tip}',
                  style: TextStyle(fontSize: 16),
                ),
                // Add more fields as needed
              ],
            ),
          );
        } else {
          return Container(
            padding: EdgeInsets.all(10),
            child: Text(
              'Nema dostupnih podataka za tip objekta.',
              style: TextStyle(fontSize: 16),
            ),
          );
        }
      }
    },
  );
}

  Future<void> _buildTipObjektaData() async {
    if (objekatData != null && objekatData!.result.isNotEmpty) {
      tipObjektaData = await _tipObjektaProvider.get(filter: {'tipObjektatId': objekatData!.result[0].tipObjektaId});
      // print("First tipObjektum: ${tipObjektaData.result[0].tip}");
      setState(() {}); // Trigger rebuild after getting tipObjektaData
    }
  }
}
