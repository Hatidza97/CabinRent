import 'dart:convert';

import 'package:cabinrent_admin/models/grad.dart';
import 'package:cabinrent_admin/models/korisnik.dart';
import 'package:cabinrent_admin/models/pictures.dart';
import 'package:cabinrent_admin/models/product.dart';
import 'package:cabinrent_admin/models/search_result.dart';
import 'package:cabinrent_admin/models/tipObjekta.dart';
import 'package:cabinrent_admin/providers/grad_provider.dart';
import 'package:cabinrent_admin/providers/klijent_provider.dart';
import 'package:cabinrent_admin/providers/korisnik_provider.dart';
import 'package:cabinrent_admin/providers/pictures_provider.dart';
import 'package:cabinrent_admin/providers/product_provider.dart';
import 'package:cabinrent_admin/providers/tip_objekta_provider.dart';
import 'package:cabinrent_admin/screens/product_detail_update_screen.dart';
import 'package:cabinrent_admin/screens/rezervacija_screen.dart';
import 'package:cabinrent_admin/widgets/master_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';
import 'package:photo_view/photo_view.dart';
import 'package:photo_view/photo_view_gallery.dart';

class ProducDetailScreen extends StatefulWidget {
  Objekat? objekat;

  ProducDetailScreen({Key? key, this.objekat}) : super(key: key);

  @override
  State<ProducDetailScreen> createState() => _ProducDetailScreenState();
}

/*
  SeearchResult<TipObjektaSllike>? resultPictures;
  late PicturesProvider _picturesProvider;
    _picturesProvider = context.read<PicturesProvider>();
*/
class _ProducDetailScreenState extends State<ProducDetailScreen> {
  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};
  SeearchResult<TipObjektaSllike>? resultPictures;
  late PicturesProvider _picturesProvider;
  late GradProvider _cityProvider;
  late TipObjektaProvider _objectTypeProvider;
  late KorisnikProvider _userProvider;
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
      'cijena': widget.objekat?.cijena,
      'tipObjektaId': widget.objekat?.tipObjektaId,
      'korisnikId': widget.objekat?.korisnikId,
    };
  }

  void didChangeDependencies() {
    super.didChangeDependencies();
    _picturesProvider = context.read<PicturesProvider>();
    _cityProvider = context.read<GradProvider>();
    _productProvider = context.read<ProductProvider>();
    _objectTypeProvider = context.read<TipObjektaProvider>();
    _userProvider = context.read<KorisnikProvider>();
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
          'cijena': widget.objekat?.cijena,
          'tipObjektaId': widget.objekat?.tipObjektaId,
          'korisnikId': widget.objekat?.korisnikId
        });
      });
    }
  }

  Widget build(BuildContext context) {
    return MasterScreenWidget(
      child: Column(
        children: [_buildForm(), _buildImageGallery()],
      ),
      title: this.widget.objekat?.naziv ?? "Object details",
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
                    child: Text("Naziv: ${widget.objekat?.naziv}"
                        ),
                  ),
                  const SizedBox(
                    width: 10,
                  ),
                  Expanded(
                    child: Text("Površina objekta: ${widget.objekat?.povrsina}"
                        ),
                  ),
                ],
              ),
            ),
            Padding(
              padding: const EdgeInsets.all(8.0),
              child: Row(
                children: [
                  Expanded(
                    child: Text(
                        "Broj mjesta (djeca) : ${widget.objekat?.brojMjestaDjeca}"),
                  ),
                  Expanded(
                    child: Text(
                        "Broj mjesta (odrasli) : ${widget.objekat?.brojMjestaOdrasli}"),
                  ),
                  Expanded(
                    child: Text(
                        "Broj mjesta (ukupno): ${widget.objekat?.brojMjestaUkupno}"),
                  ),
                ],
              ),
            ),
            SizedBox(height: 10),
            Padding(
              padding: EdgeInsets.all(10),
              child: Row(
                children: [
                  Expanded(
                    child: Text(
                        // decoration: InputDecoration(labelText: "Opis objekta"),
                        // name: "opis"
                        "Opis objekta: ${widget.objekat?.opis}"),
                  ),
                ],
              ),
            ),
            Padding(
                padding: EdgeInsets.all(10),
                child: Row(children: [
                Text("Cijena: ${widget.objekat?.cijena} KM")
                ],) 
                ),
            Padding(
              padding: EdgeInsets.all(10),
              child: Row(
                children: [
                  FutureBuilder<Widget>(
                    future: _findCity(widget.objekat?.gradId),
                    builder: (context, snapshot) {
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
                    future: _findUser(widget.objekat?.korisnikId),
                    builder: (context, snapshot) {
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
            ),
            Padding(
              padding: EdgeInsets.all(20),
              child: ElevatedButton(
                  child: Text(
                      widget.objekat?.rezervisan == true ? 'Uredi detalje objekta' : 'Uredi detalje objekta'),
                  onPressed: () {
                    try {
                      Navigator.of(context).push(MaterialPageRoute(
                          builder: (context) => ProducDetailUpdateScreen(
                                objekat: widget.objekat,
                              )));
                    } on Exception catch (e) {
                      showDialog(
                          context: context,
                          builder: (BuildContext context) => AlertDialog(
                                title: Text("Error"),
                                content: Text(e.toString()),
                                actions: [
                                  TextButton(
                                      onPressed: () => Navigator.pop(context),
                                      child: Text("ok"))
                                ],
                              ));
                    }
                  }),
            ),
            // Padding(
            //   padding: EdgeInsets.all(20),
            //   child: ElevatedButton(
            //       child: Text(widget.objekat?.rezervisan == true
            //           ? 'Rezervisan'
            //           : 'Slobodan'),
            //       onPressed: () {
            //         try {
            //           Navigator.of(context).push(MaterialPageRoute(
            //               builder: (context) => RezervacijaScreen(
            //                     objekat: widget.objekat,
            //                   )));
            //         } on Exception catch (e) {
            //           showDialog(
            //               context: context,
            //               builder: (BuildContext context) => AlertDialog(
            //                     title: Text("Error"),
            //                     content: Text(e.toString()),
            //                     actions: [
            //                       TextButton(
            //                           onPressed: () => Navigator.pop(context),
            //                           child: Text("ok"))
            //                     ],
            //                   ));
            //         }
            //       }),
            //   // child: Text(widget.objekat?.rezervisan == true
            //   //     ? "Trenutno rezervisan"
            //   //     : "Rezervisi")),
            // )
            // )
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
      if (cityResult.result.isNotEmpty) {
        Grad firstGrad = cityResult.result.first;
        String gradNaziv = firstGrad.naziv ?? ''; // Access 'naziv' property


        return Text(
          'Grad: $gradNaziv', // Display 'naziv' property in a Text widget
          style: TextStyle(fontSize: 16),
        );
      } else {
        return Container();
      }
    } catch (error) {
      return Container();
    }
  }

  Future<Widget> _findTypeOfObject(int? tipObjektaId) async {
    try {
      var objectTypeResult =
          await _objectTypeProvider.get(filter: {'tipObjektaId': tipObjektaId});
      if (objectTypeResult.result.isNotEmpty) {
        TipObjektum firstGrad = objectTypeResult.result.first;
        String tipObjektaNaziv = firstGrad.tip ?? ''; // Access 'naziv' property


        return Text(
          'Tip objekta: $tipObjektaNaziv', // Display 'naziv' property in a Text widget
          style: TextStyle(fontSize: 16),
        );
      } else {
        return Container();
      }
    } catch (error) {
      return Container();
    }
  }

    Future<Widget> _findUser(int? korisnikId) async {
    try {
      var userResult =
          await _userProvider.get(filter: {'korisnikId': korisnikId});
      if (userResult.result.isNotEmpty) {
        Korisnik user = userResult.result.first;
        String userNameSurname = '${user.ime} ${user.prezime}' ?? ''; // Access 'naziv' property


        return Text(
          'Izdavač: $userNameSurname', // Display 'naziv' property in a Text widget
          style: TextStyle(fontSize: 16),
        );
      } else {
        return Container();
      }
    } catch (error) {
      return Container();
    }
  }

  Future<Widget> _updateObjectDetails(int? objekatId) async {
    try {
      var request = new Map.from(_formKey.currentState!.value);
      return Container();
      // var objectResultUpdate = await _productProvider.update(objekatId,request);
    } catch (error) {
      return Container();
    }
  }
}
