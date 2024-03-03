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
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:provider/provider.dart';

class ProductListScreen extends StatefulWidget {
  const ProductListScreen({Key? key}) : super(key: key);

  @override
  State<ProductListScreen> createState() => _ProductListScreenState();
}

class _ProductListScreenState extends State<ProductListScreen> {
  SeearchResult<Objekat>? result;
  SeearchResult<TipObjektaSllike>? resultPictures;
  TextEditingController _nazivController = new TextEditingController();

  late ProductProvider _productProvider;
  late PicturesProvider _picturesProvider;

  @override
  void didChangeDependencies() {
    // TODO: implement didChangeDependencies
    super.didChangeDependencies();
    _productProvider = context.read<ProductProvider>();
    _picturesProvider = context.read<PicturesProvider>();
  }

  @override
  Widget build(BuildContext context) {
    var data2 = _picturesProvider.get();
    return MasterScreenWidget(
      title: 'Svi objekti',
      child: Container(
        child: Column(children: [
          Padding(
              padding: const EdgeInsets.all(8.0),
              child: Row(
                children: [
                  _newObject(),
                ],
              )),
          _buildSearch(),
          _buildDataListView()
        ]),
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
          const SizedBox(height: 40),
          ElevatedButton(
              onPressed: () async {
                var data = await _productProvider
                    .get(filter: {'naziv': _nazivController.text});
                var data2 = await _picturesProvider.get();
                setState(() {
                  result = data;
                  resultPictures = data2;
                  print("result:$result");
                });
                print("data: ${data.result[0].naziv}");
              },
              child: const Text('Pretraga')),
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
        mainAxisSize:
            MainAxisSize.min,
        children: [
          Icon(Icons.add),
          SizedBox(
              width: 8),
          Text('Dodaj novi objekat'),
        ],
      ),
    );
  }

  Expanded _buildDataListView() {
    return Expanded(
        child: SingleChildScrollView(
      child: Padding(
        padding: const EdgeInsets.all(10.0),
        child: DataTable(
          columns: const [
            DataColumn(
                label: Expanded(
              child: Text(
                "ID",
                style: TextStyle(fontStyle: FontStyle.italic),
              ),
            )),
            DataColumn(
                label: Expanded(
              child: Text(
                "Naziv",
                style: TextStyle(fontStyle: FontStyle.italic),
              ),
            )),
            DataColumn(
                label: Expanded(
              child: Text(
                "Povrsina",
                style: TextStyle(fontStyle: FontStyle.italic),
              ),
            )),
            DataColumn(
                label: Expanded(
              child: Text(
                "Slika",
                style: TextStyle(fontStyle: FontStyle.italic),
              ),
            ))
          ],
          rows: result?.result
                  .map((Objekat e) => DataRow(
                          onSelectChanged: (selected) => {
                                if (selected == true)
                                  {
                                    // print("selected${e.objekatId}")
                                    Navigator.of(context)
                                        .push(MaterialPageRoute(
                                      builder: (context) => ProducDetailScreen(
                                        objekat: e,
                                      ),
                                    ))
                                  }
                              },
                          cells: [
                            DataCell(Text(e.objekatId.toString() ?? "")),
                            DataCell(Text(e.naziv ?? "")),
                            DataCell(Text(e.povrsina ?? "")),
                            DataCell(
                              FutureBuilder<Widget>(
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
                          ]))
                  .toList() ??
              [],
        ),
      ),
    ));
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
          child: imageFromBase64String(firstPicture.imageData ?? ""),
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
