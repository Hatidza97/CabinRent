import 'dart:convert';

import 'package:cabinrent_admin/models/grad.dart';
import 'package:cabinrent_admin/models/korisnik.dart';
import 'package:cabinrent_admin/models/pictures.dart';
import 'package:cabinrent_admin/models/product.dart';
import 'package:cabinrent_admin/models/search_result.dart';
import 'package:cabinrent_admin/models/tipObjekta.dart';
import 'package:cabinrent_admin/providers/grad_provider.dart';
import 'package:cabinrent_admin/providers/korisnik_provider.dart';
import 'package:cabinrent_admin/providers/pictures_provider.dart';
import 'package:cabinrent_admin/providers/product_provider.dart';
import 'package:cabinrent_admin/providers/tip_objekta_provider.dart';
import 'package:cabinrent_admin/screens/product_list_screen.dart';
import 'package:cabinrent_admin/screens/rezervacija_screen.dart';
import 'package:cabinrent_admin/widgets/master_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';
import 'package:photo_view/photo_view.dart';
import 'package:photo_view/photo_view_gallery.dart';

class ProducDetailUpdateScreen extends StatefulWidget {
  Objekat? objekat;

  ProducDetailUpdateScreen({Key? key, this.objekat}) : super(key: key);

  @override
  State<ProducDetailUpdateScreen> createState() =>
      _ProducDetailUpdateScreenState();
}

/*
  SeearchResult<TipObjektaSllike>? resultPictures;
  late PicturesProvider _picturesProvider;
    _picturesProvider = context.read<PicturesProvider>();
*/
class _ProducDetailUpdateScreenState extends State<ProducDetailUpdateScreen> {
  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};
  SeearchResult<TipObjektaSllike>? resultPictures;
  late PicturesProvider _picturesProvider;
  late GradProvider _cityProvider;
  late KorisnikProvider _userProvider;
  late TipObjektaProvider _objectTypeProvider;
  late ProductProvider _productProvider;
  late PageController _pageController;
  @override
  void initState() {
    super.initState();
    _pageController = PageController(); // Initialize the pageController

    _initialValue = {
      'naziv': widget.objekat?.naziv,
      'povrsina': widget.objekat?.povrsina,
      'brojMjestaDjeca': widget.objekat?.brojMjestaDjeca.toString(),
      'brojMjestaOdrasli': widget.objekat?.brojMjestaOdrasli.toString(),
      'brojMjestaUkupno': widget.objekat?.brojMjestaUkupno.toString(),
      'opis': widget.objekat?.opis,
      'rezervisan': widget.objekat?.rezervisan,
      'gradId': widget.objekat?.gradId.toString(),
      'cijena': widget.objekat?.cijena.toString(),
      'tipObjektaId': widget.objekat?.tipObjektaId.toString(),
      'korisnikId': widget.objekat?.korisnikId.toString()
    };
  }

  void didChangeDependencies() {
    super.didChangeDependencies();
    _picturesProvider = context.read<PicturesProvider>();
    _cityProvider = context.read<GradProvider>();
    _productProvider = context.read<ProductProvider>();
    _objectTypeProvider = context.read<TipObjektaProvider>();
    _userProvider = context.read<KorisnikProvider>();
    print(_picturesProvider);
    if (widget.objekat != null) {
      setState(() {
        _formKey.currentState?.patchValue({
          'naziv': widget.objekat?.naziv,
          'povrsina': widget.objekat?.povrsina,
          'brojMjestaDjeca': widget.objekat?.brojMjestaDjeca.toString(),
          'brojMjestaOdrasli': widget.objekat?.brojMjestaOdrasli.toString(),
          'brojMjestaUkupno': widget.objekat?.brojMjestaUkupno.toString(),
          'opis': widget.objekat?.opis,
          'rezervisan': widget.objekat?.rezervisan,
          'gradId': widget.objekat?.gradId.toString(),
          'cijena': widget.objekat?.cijena.toString(),
          'tipObjektaId': widget.objekat?.tipObjektaId.toString(),
          'korisnikId': widget.objekat?.korisnikId.toString()
        });
      });
    }
  }

  Widget build(BuildContext context) {
    return MasterScreenWidget(
      child: Column(
        children: [
          _buildForm(),
          _buildImageGallery(),
          ElevatedButton(
              onPressed: () async {
                _formKey.currentState?.saveAndValidate();
                print("TRENUTNOSTANJE:${_formKey.currentState?.value}");
                var request = new Map.from(_formKey.currentState!.value);
                try {
                  await _productProvider.update(
                      widget.objekat!.objekatId!, request);

                  // Show a success message using a dialog
                  showDialog(
                    context: context,
                    builder: (BuildContext context) => AlertDialog(
                      title: Text("Success"),
                      content: Text("Vaše izmjene su uspješno sačuvane!"),
                      actions: [
                        TextButton(
                          onPressed: () {
                            Navigator.pop(context); // Close the dialog
                            Navigator.of(context).push(
                              MaterialPageRoute(
                                builder: (context) => const ProductListScreen(),
                              ),
                            );
                          },
                          child: Text("OK"),
                        ),
                      ],
                    ),
                  );
                } on Exception catch (e) {
                  showDialog(
                      context: context,
                      builder: (BuildContext context) => AlertDialog(
                            title: Text("Error"),
                            content: Text(e.toString()),
                            actions: [
                              TextButton(
                                  onPressed: () => Navigator.pop(context),
                                  child: Text("OK"))
                            ],
                          ));
                }
              },
              child: Text("Sacuvaj izmjene"))
        ],
      ),
      title: this.widget.objekat?.naziv ?? "Product details",
    );
  }

  FormBuilder _buildForm() {
    return FormBuilder(
        key: _formKey,
        initialValue: _initialValue,
        child: Column(
          children: [
            // Expanded(child:
            Padding(
              padding: const EdgeInsets.all(8.0),
              child: Row(
                children: [
                  Expanded(
                    child: FormBuilderTextField(
                        decoration: InputDecoration(labelText: "Naziv"),
                        name: "naziv"),
                  ),
                  const SizedBox(
                    width: 10,
                  ),
                  Expanded(
                    child: FormBuilderTextField(
                        decoration: InputDecoration(labelText: "Površina"),
                        name: "povrsina"),
                  ),
                ],
              ),
            ),
            Padding(
              padding: const EdgeInsets.all(8.0),
              child: Row(
                children: [
                  Expanded(
                    child: FormBuilderTextField(
                        decoration:
                            InputDecoration(labelText: "Broj mjesta (djeca)"),
                        name: "brojMjestaDjeca"),
                  ),
                  Expanded(
                    child: FormBuilderTextField(
                        decoration:
                            InputDecoration(labelText: "Broj mjesta (odrasli)"),
                        name: "brojMjestaOdrasli"),
                  ),
                  Expanded(
                    child: FormBuilderTextField(
                        decoration:
                            InputDecoration(labelText: "Broj mjesta (ukupno)"),
                        name: "brojMjestaUkupno"),
                  ),
                ],
              ),
            ),
            Padding(
              padding: EdgeInsets.all(10),
              child: Row(
                children: [
                  Expanded(
                    child: FormBuilderTextField(
                        decoration: InputDecoration(labelText: "Opis objekta"),
                        name: 'opis'),
                  ),
                  Expanded(
                      child: FormBuilderTextField(
                          decoration: InputDecoration(labelText: "Cijena:"),
                          name: 'cijena',
                         )),
                  Expanded(
                      child: FormBuilderTextField(
                          name: 'tipObjektaId',
                           enabled: false,
                          decoration:
                              InputDecoration(labelText: "Tip objekta (ID):"))),
                  Expanded(
                      child: FormBuilderTextField(
                          name: 'gradId',
                           enabled: false,
                          decoration:
                              InputDecoration(labelText: "Grad (ID):"))),
                ],
              ),
            ),
            Padding(
              padding: EdgeInsets.all(10),
              child: Row(
                children: [
                  FutureBuilder<Widget>(
                    future: _findCity(widget.objekat?.gradId),
                    builder: (context, snapshot) {
                      print("snapshot:${snapshot.data}");
                      if (snapshot.connectionState == ConnectionState.waiting) {
                        return CircularProgressIndicator(); // or any other loading indicator
                      } else if (snapshot.hasError) {
                        return Text('Error: ${snapshot.error}');
                      } else {
                        return snapshot.data ??
                            Container(); // return the widget or an empty container
                      }
                    },
                  ),
                  SizedBox(
                    width: 30,
                  ),
                  FutureBuilder<Widget>(
                    future: _findUser(widget.objekat?.korisnikId),
                    builder: (context, snapshot) {
                      print("useruser:${widget.objekat?.korisnikId}");
                      if (snapshot.connectionState == ConnectionState.waiting) {
                        return CircularProgressIndicator(); // or any other loading indicator
                      } else if (snapshot.hasError) {
                        return Text('Error: ${snapshot.error}');
                      } else {
                        return snapshot.data ??
                            Container(); // return the widget or an empty container
                      }
                    },
                  ),
                ],
              ),
            ),
            Padding(
              padding: EdgeInsets.all(10),
              child: Row(
                children: [
                  FutureBuilder<Widget>(
                    future: _findTypeOfObject(widget.objekat?.tipObjektaId),
                    builder: (context, snapshot) {
                      print("snapshot:${snapshot.data}");
                      if (snapshot.connectionState == ConnectionState.waiting) {
                        return CircularProgressIndicator(); // or any other loading indicator
                      } else if (snapshot.hasError) {
                        return Text('Error: ${snapshot.error}');
                      } else {
                        return snapshot.data ??
                            Container(); // return the widget or an empty container
                      }
                    },
                  ),
                ],
              ),
            ),
            Padding(
              padding: EdgeInsets.all(10),
              child: Row(
                children: [
                  const Text(
                    'Stanje rezervacije:',
                    style: TextStyle(fontSize: 16),
                  ),
                  Text(
                    widget.objekat?.rezervisan == true
                        ? 'Trenutno rezervisan'
                        : 'Slobodan',
                    style: TextStyle(fontSize: 16),
                  )
                ],
              ),
            ),
            Padding(
              padding: EdgeInsets.all(10),
              child: Row(children: [
                FutureBuilder<Widget>(
                  future:
                      _updateObjectDetails(widget.objekat?.objekatId ?? null),
                  builder: (context, snapshot) {
                    print("snapshot:${snapshot.data}");
                    if (snapshot.connectionState == ConnectionState.waiting) {
                      return CircularProgressIndicator(); // or any other loading indicator
                    } else if (snapshot.hasError) {
                      return Text('Error: ${snapshot.error}');
                    } else {
                      return snapshot.data ??
                          Container(); // return the widget or an empty container
                    }
                  },
                ),
              ]),
            )
          ],
        ));
  }

  Widget _buildImageGallery() {
    return FutureBuilder<SeearchResult<TipObjektaSllike>>(
      future: _picturesProvider
          .get(filter: {'objekatId': widget.objekat?.objekatId.toString()}),
      builder: (BuildContext context,
          AsyncSnapshot<SeearchResult<TipObjektaSllike>> snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return CircularProgressIndicator(); // Show loading indicator while waiting for the response
        } else if (snapshot.hasError) {
          return Text('Error: ${snapshot.error}');
        } else if (snapshot.hasData &&
            snapshot.data?.result.isNotEmpty == true) {
          List<PhotoViewGalleryPageOptions> imagePages = [];

          for (TipObjektaSllike image in snapshot.data!.result) {
            imagePages.add(
              PhotoViewGalleryPageOptions(
                imageProvider: MemoryImage(base64Decode(image.imageData!)),
                minScale: PhotoViewComputedScale.contained,
                maxScale: PhotoViewComputedScale.covered * 2,
              ),
            );
          }

          late PageController _pageController;
          _pageController = PageController();

          return SizedBox(
            height: 300,
            child: Column(
              children: [
                Expanded(
                  child: PhotoViewGallery.builder(
                    itemCount: imagePages.length,
                    builder: (context, index) {
                      return PhotoViewGalleryPageOptions(
                        imageProvider: imagePages[index].imageProvider,
                        minScale: imagePages[index].minScale,
                        maxScale: imagePages[index].maxScale,
                        heroAttributes:
                            PhotoViewHeroAttributes(tag: index.toString()),
                      );
                    },
                    scrollPhysics: AlwaysScrollableScrollPhysics(),
                    backgroundDecoration: BoxDecoration(
                      color: Colors.blueGrey[100],
                    ),
                    pageController: _pageController,
                    onPageChanged: (index) {},
                  ),
                ),
                Row(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    IconButton(
                      icon: Icon(Icons.arrow_left),
                      onPressed: () {
                        int currentPage = (_pageController.page ?? 0).round();
                        if (currentPage > 0) {
                          _pageController.jumpToPage(currentPage - 1);
                        }
                      },
                    ),
                    IconButton(
                      icon: Icon(Icons.arrow_right),
                      onPressed: () {
                        int currentPage = (_pageController.page ?? 0).round();
                        if (currentPage < imagePages.length - 1) {
                          _pageController.jumpToPage(currentPage + 1);
                        }
                      },
                    ),
                  ],
                ),
              ],
            ),
          );
        } else {
          return const Text('Trenutno nema dostupnih slika.');
        }
      },
    );
  }

  Future<Widget> _findCity(int? gradId) async {
    try {
      var cityResult = await _cityProvider.get(filter: {'gradId': gradId});
      print(cityResult);
      if (cityResult.result.isNotEmpty) {
        Grad firstGrad = cityResult.result.first;
        String gradNaziv = firstGrad.naziv ?? ''; // Access 'naziv' property

        print("grad: $gradNaziv");

        return Text(
          'Grad: $gradNaziv', // Display 'naziv' property in a Text widget
          style: TextStyle(fontSize: 16),
        );
      } else {
        return Container();
      }
    } catch (error) {
      print('Error getting data: $error');
      return Container();
    }
  }

  Future<Widget> _findTypeOfObject(int? tipObjektaId) async {
    try {
      var objectTypeResult =
          await _objectTypeProvider.get(filter: {'tipObjektaId': tipObjektaId});
      print(objectTypeResult);
      if (objectTypeResult.result.isNotEmpty) {
        TipObjektum firstGrad = objectTypeResult.result.first;
        String tipObjektaNaziv = firstGrad.tip ?? ''; // Access 'naziv' property

        print("TipObjekta: $tipObjektaNaziv");

        return Text(
          'Tip objekta: $tipObjektaNaziv', // Display 'naziv' property in a Text widget
          style: TextStyle(fontSize: 16),
        );
      } else {
        return Container();
      }
    } catch (error) {
      print('Error getting data: $error');
      return Container();
    }
  }

  Future<Widget> _findUser(int? korisnikId) async {
    print("korisnikId:${korisnikId}");
    try {
      var userResult =
          await _userProvider.get(filter: {'korisnikId': korisnikId});
      print(userResult);
      if (userResult.result.isNotEmpty) {
        Korisnik user = userResult.result.first;
        String userNameSurname =
            '${user.ime} ${user.prezime}' ?? ''; // Access 'naziv' property

        print("Izdavac: $userNameSurname");

        return Text(
          'Izdavač: $userNameSurname', // Display 'naziv' property in a Text widget
          style: TextStyle(fontSize: 16),
        );
      } else {
        return Container();
      }
    } catch (error) {
      print('Error getting data: $error');
      return Container();
    }
  }

  Future<Widget> _updateObjectDetails(int? objekatId) async {
    try {
      var request = new Map.from(_formKey.currentState!.value);
      print("request:$request");
      return Container();
      // var objectResultUpdate = await _productProvider.update(objekatId,request);
    } catch (error) {
      print('Error getting data: $error');
      return Container();
    }
  }
}
