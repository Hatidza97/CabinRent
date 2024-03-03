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

class RezervacijaScreen extends StatefulWidget {
  Objekat? objekat;

  RezervacijaScreen({Key? key, this.objekat}) : super(key: key);

  @override
  State<RezervacijaScreen> createState() => _RezervacijaScreenState();
}

class _RezervacijaScreenState extends State<RezervacijaScreen> {
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
          _buildForm(),
        ]),
      ),
    );
  }
  
  Future<List<DateTime>> _findReservationDates(int? objekatId) async {
    var reservationDates =
        await _rezervacijaProvider.get(filter: {'objekatId': objekatId});
    Rezervacija rezervacijaDatumi = reservationDates.result.first;
    String? datumOd = rezervacijaDatumi.datumPrijave ?? "";
    String? datumDo = rezervacijaDatumi.datumOdjave ?? "";

    DateTime? startDate = DateTime.tryParse(datumOd ?? "");
    DateTime? endDate = DateTime.tryParse(datumDo ?? "");

    if (startDate != null && endDate != null) {
      for (var day = startDate;
          day.isBefore(endDate);
          day = day.add(Duration(days: 1))) {
        dateList.add(day);
      }
      return dateList;
    }

    return [];
  }

  FormBuilder _buildForm() {
    List<DateTime> reservedDates = dateList;
    print("reservedDates:$dateList");
    return FormBuilder(
      key: _formKey,
      initialValue: _initialValue,
      child: Column(
        children: [
          Padding(
              padding: EdgeInsets.all(10),
              child: Row(
                children: [
                  Expanded(
                    child: FormBuilderTextField(
                        decoration: InputDecoration(labelText: "Naziv"),
                        name: "naziv"),
                  ),
                ],
              )),
          Padding(
              padding: EdgeInsets.all(10),
              child: Row(
                children: [
                  Expanded(
                    child: FormBuilderTextField(
                        decoration:
                            InputDecoration(labelText: "Broj mjesta (djeca)"),
                        name: "brojMjestaDjeca"),
                  ),
                ],
              )),
          Padding(
              padding: EdgeInsets.all(10),
              child: Row(
                children: [
                  Expanded(
                    child: FormBuilderTextField(
                        decoration:
                            InputDecoration(labelText: "Broj mjesta (odrasli)"),
                        name: "brojMjestaOdrasli"),
                  ),
                ],
              )),
          Padding(
            padding: EdgeInsets.all(10),
            child: Row(
              children: [
                FutureBuilder<Widget>(
                  future: _findCurrentReservation(widget.objekat?.objekatId),
                  builder: (context, snapshot) {
                    if (snapshot.connectionState == ConnectionState.waiting) {
                      return CircularProgressIndicator();
                    } else if (snapshot.hasError) {
                      return Text('Error: ${snapshot.error}');
                    } else {
                      return snapshot.data ?? Container();
                    }
                  },
                ),
                Padding(
                  padding: EdgeInsets.all(10),
                  child: ElevatedButton(
                    onPressed: () {
                      _selectDate(context, reservedDates, true);
                    },
                    child: Text(
                        'Datum prijave: ${_selectedPrijaveDate ?? "Odaberite datum"}'),
                  ),
                ),
                Padding(
                  padding: EdgeInsets.all(10),
                  child: ElevatedButton(
                    onPressed: () {
                      _selectDate(context, reservedDates, false);
                    },
                    child: Text(
                        'Datum odjave: ${_selectedOdjaveDate ?? "Odaberite datum"}'),
                  ),
                ),
                // Padding(
                //   padding: EdgeInsets.all(10),
                //   child: Row(
                //     children: [
                //       FutureBuilder<List<DateTime>>(
                //         future:
                //             _findReservationDates(widget.objekat?.objekatId),
                //         builder: (context, snapshot) {
                //           if (snapshot.connectionState ==
                //               ConnectionState.waiting) {
                //             return CircularProgressIndicator();
                //           } else if (snapshot.hasError) {
                //             return Text('Error: ${snapshot.error}');
                //           } else {
                //             List<DateTime> reservedDates = snapshot.data ?? [];
                //             return snapshot.data != null
                //                 ? const Expanded(
                //                     child: (Text("TEST")),
                //                   )
                //                 : Container();
                //           }
                //         },
                //       ),
                //     ],
                //   ),
                // ),
              ],
            ),
          ),
        ],
      ),
    );
  }

  Future<Widget> _findCurrentReservation(int? objekatId) async {
    try {
      var reservationResult =
          await _productProvider.get(filter: {'objekatId': objekatId});

      if (reservationResult.result.isNotEmpty) {
        Objekat rezervacija = reservationResult.result.first;
        bool gradNaziv = rezervacija.rezervisan;

        return Container();
      } else {
        return Container();
      }
    } catch (error) {
      print('Error getting picture data: $error');
      return Container();
    }
  }

  bool isDateDisabled(DateTime date, List<DateTime> reservedDates) {
    // Replace this with your actual logic to check if a date is reserved
    return reservedDates.contains(date);
  }

  void _selectDate(BuildContext context, List<DateTime> reservedDates,
      bool isPrijave) async {
    DateTime currentDate = DateTime.now();
    DateTime startDate = DateTime(2022, 4, 1, 1, 10);
    print(startDate);
    DateTime? selectedDate = await showDatePicker(
      context: context,
      initialDate: currentDate,
      firstDate: startDate,
      lastDate: currentDate.add(Duration(days: 365)),
      selectableDayPredicate: (DateTime day) {
        print("selectable:${!isDateDisabled(day, reservedDates)}");
        return !isDateDisabled(day, reservedDates);
      },
    );

    if (selectedDate != null) {
      setState(() {
        if (isPrijave) {
          _selectedPrijaveDate = selectedDate;
        } else {
          _selectedOdjaveDate = selectedDate;
        }
      });
      print('Selected date: $selectedDate');
    }
  }
}
