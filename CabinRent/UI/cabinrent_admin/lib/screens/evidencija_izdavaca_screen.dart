import 'dart:typed_data';
import 'package:cabinrent_admin/models/korisnik.dart';
import 'package:cabinrent_admin/models/product.dart';
import 'package:cabinrent_admin/models/search_result.dart';
import 'package:cabinrent_admin/providers/korisnik_provider.dart';
import 'package:cabinrent_admin/providers/product_provider.dart';
import 'package:cabinrent_admin/utils/util.dart';
import 'package:cabinrent_admin/widgets/master_screen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'dart:convert';
import 'package:convert/convert.dart';

class IzdavacListScreen extends StatefulWidget {
  IzdavacListScreen({Key? key}) : super(key: key);

  @override
  State<IzdavacListScreen> createState() => _IzdavacListScreenState();
}

class _IzdavacListScreenState extends State<IzdavacListScreen> {
  SeearchResult<Objekat>? result;
  SeearchResult<Korisnik>? resultUsers;

  late ProductProvider _productProvider;
  late KorisnikProvider _userProvider;

  int? selectedUserId;
  bool isButtonVisible = false;

  @override
  void initState() {
    super.initState();
    _productProvider = context.read<ProductProvider>();
    _userProvider = context.read<KorisnikProvider>();
  }

  Widget build(BuildContext context) {
    return MasterScreenWidget(
      title: 'Svi izdavaci',
      child: Container(
        child: Column(
          children: [
            Padding(
              padding: EdgeInsets.all(10),
              child: Row(
                children: [
                  _buildSearchIzdavaci(),
                ],
              ),
            ),
            Expanded(
              child: _buildDataListView(),
            ),
          ],
        ),
      ),
    );
  }

  Widget _buildSearchIzdavaci() {
    return Padding(
      padding: EdgeInsets.all(10),
      child: ElevatedButton(
        onPressed: () async {
          var data = await _userProvider.get();
          setState(() {
            resultUsers = data;
          });
        },
        child: const Text('Ucitaj sve izdavace'),
      ),
    );
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
                "Ime",
                style: TextStyle(fontStyle: FontStyle.italic),
              ),
            ),
            DataColumn(
              label: Text(
                "Prezime",
                style: TextStyle(fontStyle: FontStyle.italic),
              ),
            ),
            DataColumn(
              label: Text(
                "Slika",
                style: TextStyle(fontStyle: FontStyle.italic),
              ),
            ),
            DataColumn(
              label: Text(
                "Obrisi",
                style: TextStyle(fontStyle: FontStyle.italic),
              ),
            )
          ],
          rows: resultUsers?.result
                  .map(
                    (Korisnik e) => DataRow(
                      onSelectChanged: (selected) {
                        setState(() {
                          if (selected != null && selected) {
                            selectedUserId = e.korisnikId;
                            isButtonVisible = true;
                          } else {
                            selectedUserId = null;
                            isButtonVisible = false;
                          }
                        });
                      },
                      cells: [
                        DataCell(Text(e.korisnikId.toString() ?? "")),
                        DataCell(Text(e.ime ?? "")),
                        DataCell(Text(e.prezime ?? "")),
                        DataCell(
                          FutureBuilder<Widget>(
                            future: _buildFirstImageWidget(e.korisnikId),
                            builder: (context, snapshot) {
                              if (snapshot.connectionState ==
                                  ConnectionState.waiting) {
                                return CircularProgressIndicator();
                              } else if (snapshot.hasError) {
                                return Text('Error: ${snapshot.error}');
                              } else if (snapshot.data != null) {
                                return snapshot.data!;
                              } else {
                                return Container(); // Return a default widget when data is null
                              }
                            },
                          ),
                        ),
                        DataCell(
                          Visibility(
                            visible: isButtonVisible,
                            child: ElevatedButton(
                              onPressed: () {
                                _deleteSelectedRow(e.korisnikId!);
                              },
                              child: Text('Delete'),
                            ),
                          ),
                        )
                      ],
                    ),
                  )
                  .toList() ??
              [],
        ),
      ),
    );
  }

  Future<Widget> _buildFirstImageWidget(int? korisnikId) async {
    try {
      var userResult =
          await _userProvider.get(filter: {'korisnikId': korisnikId});
      if (userResult.result.isNotEmpty) {
        Korisnik firstPicture = userResult.result.first;
        return Container(
          width: 100,
          height: 100,
          child: imageFromBase64String(firstPicture.slika ?? ""),
        );
      } else {
        return Container();
      }
    } catch (error) {
      print('Error getting picture data: $error');
      return Container();
    }
  }

  void _deleteSelectedRow(int korisnikId) async {
    try {
      var deleted = await _userProvider.delete(korisnikId);
      if (deleted) {
        // Refresh the list of users after successful deletion
        var updatedData = await _userProvider.get();
        setState(() {
          resultUsers = updatedData;
        });
        // Show snackbar to indicate successful deletion
        ScaffoldMessenger.of(context).showSnackBar(
          SnackBar(
            content: Text('User deleted successfully'),
            duration: Duration(seconds: 2), // Adjust duration as needed
          ),
        );
      } else {
        // Handle case where deletion was unsuccessful
        print('Failed to delete user');
      }
    } catch (error) {
      print('Error deleting user: $error');
    }
  }
}
