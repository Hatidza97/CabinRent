import 'dart:convert';
import 'dart:typed_data';

import 'package:cabinrent_admin/models/pictures.dart';
import 'package:cabinrent_admin/models/product.dart';
import 'package:cabinrent_admin/models/search_result.dart';
import 'package:cabinrent_admin/providers/pictures_provider.dart';
import 'package:cabinrent_admin/providers/product_provider.dart';
import 'package:cabinrent_admin/screens/new_product_screen.dart';
import 'package:cabinrent_admin/screens/product_detail_screen.dart';
import 'package:cabinrent_admin/utils/util.dart';
import 'package:cabinrent_admin/widgets/master_screen.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class ProductListScreen extends StatefulWidget {
  const ProductListScreen({Key? key}) : super(key: key);

  @override
  State<ProductListScreen> createState() => _ProductListScreenState();
}

class _ProductListScreenState extends State<ProductListScreen> {
  SeearchResult<Objekat>? result;
  SeearchResult<TipObjektaSllike>? resultPictures;
  TextEditingController _nazivController = TextEditingController();

  late ProductProvider _productProvider;
  late PicturesProvider _picturesProvider;

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
    _productProvider = context.read<ProductProvider>();
    _picturesProvider = context.read<PicturesProvider>();
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      title: 'Svi objekti',
      child: Column(
        children: [
          Padding(
            padding: const EdgeInsets.all(8.0),
            child: Row(
              children: [
                _newObject(),
              ],
            ),
          ),
          _buildSearch(),
          Expanded(
              child:
                  _buildDataListView()), // Utilize Expanded to fill remaining space
        ],
      ),
    );
  }

  Widget _buildSearch() {
    return Padding(
      padding: const EdgeInsets.all(8.0),
      child: Row(
        children: [
          Expanded(
            child: TextField(
              decoration: InputDecoration(labelText: 'Naziv objekta:'),
              controller: _nazivController,
            ),
          ),
          const SizedBox(width: 8), // Adjust spacing
          ElevatedButton(
            onPressed: () async {
              var data = await _productProvider
                  .get(filter: {'naziv': _nazivController.text});
              var data2 = await _picturesProvider.get();
              setState(() {
                result = data;
                resultPictures = data2;
              });
            },
            child: const Text('Pretraga'),
            style: ElevatedButton.styleFrom(
              primary: Colors.blue, // Add color to the button
            ),
          ),
        ],
      ),
    );
  }

  ElevatedButton _newObject() {
    return ElevatedButton(
      onPressed: () {
        Navigator.of(context).push(
          MaterialPageRoute(builder: (context) => ProductInsertScreen()),
        );
      },
      child: const Row(
        mainAxisSize: MainAxisSize.min,
        children: [
          Icon(Icons.add),
          SizedBox(width: 8),
          Text('Dodaj novi objekat'),
        ],
      ),
      style: ElevatedButton.styleFrom(
        primary: Colors.green, // Add color to the button
      ),
    );
  }

  Widget _buildDataListView() {
    return SingleChildScrollView(
      scrollDirection: Axis.horizontal, // Allow horizontal scrolling
      child: SingleChildScrollView(
        child: SizedBox(
          width: MediaQuery.of(context).size.width, // Set width to fill screen
          child: DataTable(
            columnSpacing: 16, // Adjust spacing between columns
            columns: [
              DataColumn(
                label: SizedBox(
                  child: Text(
                    "ID",
                    style: TextStyle(fontStyle: FontStyle.italic),
                  ),
                ),
              ),
              DataColumn(
                label: SizedBox(
                  child: Text(
                    "Naziv",
                    style: TextStyle(fontStyle: FontStyle.italic),
                  ),
                ),
              ),
              DataColumn(
                label: SizedBox(
                  child: Text(
                    "Povrsina",
                    style: TextStyle(fontStyle: FontStyle.italic),
                  ),
                ),
              ),
              DataColumn(
                label: Text(
                  "Slika",
                  style: TextStyle(fontStyle: FontStyle.italic),
                ),
              ),
            ],
            rows: result?.result.map((Objekat e) {
                  return DataRow(
                    onSelectChanged: (selected) {
                      if (selected == true) {
                        Navigator.of(context).push(
                          MaterialPageRoute(
                            builder: (context) => ProducDetailScreen(
                              objekat: e,
                            ),
                          ),
                        );
                      }
                    },
                    cells: [
                      DataCell(Text(e.objekatId.toString() ?? "")),
                      DataCell(Text(e.naziv ?? "")),
                      DataCell(Text(e.povrsina ?? "")),
                      DataCell(
                        SizedBox(
                          width: 100,
                          height: 100,
                          child: FutureBuilder<Widget>(
                            future: _buildFirstImageWidget(e.objekatId),
                            builder: (context, snapshot) {
                              if (snapshot.connectionState ==
                                  ConnectionState.waiting) {
                                return CircularProgressIndicator();
                              } else if (snapshot.hasError) {
                                return Text('Error: ${snapshot.error}');
                              } else {
                                return snapshot.data ?? Container();
                              }
                            },
                          ),
                        ),
                      ),
                    ],
                  );
                }).toList() ??
                [],
          ),
        ),
      ),
    );
  }

  Future<Widget> _buildFirstImageWidget(int? objekatId) async {
    try {
      var picturesResult =
          await _picturesProvider.get(filter: {'objekatId': objekatId});
      if (picturesResult.result.isNotEmpty) {
        TipObjektaSllike firstPicture = picturesResult.result.first;
        return Container(
          width: 100,
          height: 100,
          decoration: BoxDecoration(
            image: DecorationImage(
              image: MemoryImage(base64Decode(firstPicture.imageData ?? "")),
              fit: BoxFit.cover,
            ),
          ),
        );
      } else {
        return Container();
      }
    } catch (error) {
      print('Error getting picture data: $error');
      return Container();
    }
  }
}
