<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PeliculasTotal.aspx.cs" Inherits="ProyectoFinalParte2.Paginas.PeliculasTotal" Async="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Css/stiloPeli.css" rel="stylesheet" />

    <div class="Wdgt alpha-list">
        <ul class="MovieList">
            <li>
                <div class="TPost A">
                    <div class="Image">
                        <% for (int i = 0; i < peliculasRecientes.Count; i++) { %><div class="movie-item">

                                <figure class="Objf TpMvPlay AAIco-play_arrow">
                                    <img src="data:image/jpeg;base64,<%= Convert.ToBase64String(peliculasRecientes[i].PosterImage) %>" class="img d-block w-15" alt="Poster de la película" />
                                </figure>
                                <div class="movie-info" >
                                    <div class="Title">
                                        <a href='<%= "DetallePeliculas.aspx?nombre=" + peliculasRecientes[i].Nombre %>' style="text-decoration: none; color: #ffffff;"><%= peliculasRecientes[i].Nombre %></a>
                                    </div>
                                    <p><strong>Fecha de Salida:</strong> <%= peliculasRecientes[i].FechaSalida.ToString("yyyy-MM-dd") %></p>
                                    <p><strong>Calificación:</strong> <%= peliculasRecientes[i].Calificación %></p>
                                </div>
                            </div>

                        <% } %>
                    </div>
                </div>
            </li>
        </ul>
    </div>
</asp:Content>



                   <%-- <nav class="navigation pagination">
                        <div class="nav-links">
                          <a href="?page=1" data-page="1" class="page-link current">1</a><a href="?page=2" data-page="2" class="page-link ">2</a><a href="?page=3" data-page="3" class="page-link ">3</a><a href="?page=4" data-page="4" class="page-link ">4</a><a href="?page=5" data-page="5" class="page-link ">5</a><a href="?page=6" data-page="6" class="page-link ">6</a><a href="?page=2" data-page="2" class="next page-numbers"><i class="fa-arrow-right"></i></a>  
                        </div>
                    </nav>--%>

<%-- <li>
                            <div class="TPost A">
                            <a href="/18464/fabian-oder-der-gang-vor-die-hunde">
                                <div class="Image">
                                    <figure class="Objf TpMvPlay AAIco-play_arrow">
                                        <img src="//pelisimg.online/cover/fabian-oder-der-gang-vor-die-hunde-2-1668829798.jpg" alt="img">
                                    </figure>
                                </div>
                                <div class="Title">Fabian</div>
                            </a>
                            <p class="Info">
                                <span class="Date AAIco-date_range">2021</span>
                            </p>
                            </div>
                        </li>
                                                <li>
                            <div class="TPost A">
                            <a href="/20473/fables-for-the-witching-hour">
                                <div class="Image">
                                    <figure class="Objf TpMvPlay AAIco-play_arrow">
                                        <img src="//pelisimg.online/cover/fables-for-the-witching-hour-1697034902.png" alt="img">
                                    </figure>
                                </div>
                                <div class="Title">Fables for the Witching Hour</div>
                            </a>
                            <p class="Info">
                                <span class="Date AAIco-date_range">2023</span>
                            </p>
                            </div>
                        </li>
                                                <li>
                            <div class="TPost A">
                            <a href="/4459/fabricated-city">
                                <div class="Image">
                                    <figure class="Objf TpMvPlay AAIco-play_arrow">
                                        <img src="//pelisimg.online/cover/fabricated-city.jpg" alt="img">
                                    </figure>
                                </div>
                                <div class="Title">Fabricated City</div>
                            </a>
                            <p class="Info">
                                <span class="Date AAIco-date_range">2017</span>
                            </p>
                            </div>
                        </li>
                                                <li>
                            <div class="TPost A">
                            <a href="/20082/face-of-evil">
                                <div class="Image">
                                    <figure class="Objf TpMvPlay AAIco-play_arrow">
                                        <img src="//pelisimg.online/cover/face-of-evil-1692978343.png" alt="img">
                                    </figure>
                                </div>
                                <div class="Title">Face of Evil</div>
                            </a>
                            <p class="Info">
                                <span class="Date AAIco-date_range">2016</span>
                            </p>
                            </div>
                        </li>
                                                <li>
                            <div class="TPost A">
                            <a href="/20081/fade-out-ray">
                                <div class="Image">
                                    <figure class="Objf TpMvPlay AAIco-play_arrow">
                                        <img src="//pelisimg.online/cover/fade-out-ray-1692978151.png" alt="img">
                                    </figure>
                                </div>
                                <div class="Title">Fade Out Ray</div>
                            </a>
                            <p class="Info">
                                <span class="Date AAIco-date_range">2021</span>
                            </p>
                            </div>
                        </li>
                                                <li>
                            <div class="TPost A">
                            <a href="/9490/fahim">
                                <div class="Image">
                                    <figure class="Objf TpMvPlay AAIco-play_arrow">
                                        <img src="//pelisimg.online/cover/fahim-2-1590633603.jpg" alt="img">
                                    </figure>
                                </div>
                                <div class="Title">Fahim</div>
                            </a>
                            <p class="Info">
                                <span class="Date AAIco-date_range">2019</span>
                            </p>
                            </div>
                        </li>
                                                <li>
                            <div class="TPost A">
                            <a href="/2425/fahrenheit-11-9">
                                <div class="Image">
                                    <figure class="Objf TpMvPlay AAIco-play_arrow">
                                        <img src="//pelisimg.online/cover/fahrenheit-11-9.jpg" alt="img">
                                    </figure>
                                </div>
                                <div class="Title">Fahrenheit 11/9</div>
                            </a>
                            <p class="Info">
                                <span class="Date AAIco-date_range">2018</span>
                            </p>
                            </div>
                        </li>
                                                <li>
                            <div class="TPost A">
                            <a href="/3561/fahrenheit-451">
                                <div class="Image">
                                    <figure class="Objf TpMvPlay AAIco-play_arrow">
                                        <img src="//pelisimg.online/cover/fahrenheit-451.jpg" alt="img">
                                    </figure>
                                </div>
                                <div class="Title">Fahrenheit 451</div>
                            </a>
                            <p class="Info">
                                <span class="Date AAIco-date_range">2018</span>
                            </p>
                            </div>
                        </li>
                                                <li>
                            <div class="TPost A">
                            <a href="/11992/faith-under-fire">
                                <div class="Image">
                                    <figure class="Objf TpMvPlay AAIco-play_arrow">
                                        <img src="//pelisimg.online/cover/faith-under-fire-2-1607652483.jpg" alt="img">
                                    </figure>
                                </div>
                                <div class="Title">Faith Under Fire</div>
                            </a>
                            <p class="Info">
                                <span class="Date AAIco-date_range">2020</span>
                            </p>
                            </div>
                        </li>
                                                <li>
                            <div class="TPost A">
                            <a href="/9119/faith-hope-love">
                                <div class="Image">
                                    <figure class="Objf TpMvPlay AAIco-play_arrow">
                                        <img src="//pelisimg.online/cover/faith-hope-love-2-1587828124.jpg" alt="img">
                                    </figure>
                                </div>
                                <div class="Title">Faith, Hope &amp; Love</div>
                            </a>
                            <p class="Info">
                                <span class="Date AAIco-date_range">2019</span>
                            </p>
                            </div>
                        </li>
                                                <li>
                            <div class="TPost A">
                            <a href="/9561/faith-hope-y-love">
                                <div class="Image">
                                    <figure class="Objf TpMvPlay AAIco-play_arrow">
                                        <img src="//pelisimg.online/cover/faith-hope-y-love-1590825417.jpg" alt="img">
                                    </figure>
                                </div>
                                <div class="Title">Faith, Hope &amp; Love</div>
                            </a>
                            <p class="Info">
                                <span class="Date AAIco-date_range">2019</span>
                            </p>
                            </div>
                        </li>
                                                <li>
                            <div class="TPost A">
                            <a href="/19447/faithfully-yours">
                                <div class="Image">
                                    <figure class="Objf TpMvPlay AAIco-play_arrow">
                                        <img src="//pelisimg.online/cover/faithfully-yours-1685161941.png" alt="img">
                                    </figure>
                                </div>
                                <div class="Title">Faithfully Yours</div>
                            </a>
                            <p class="Info">
                                <span class="Date AAIco-date_range">2022</span>
                            </p>
                            </div>
                        </li>
                                                <li>
                            <div class="TPost A">
                            <a href="/12555/fake-famous">
                                <div class="Image">
                                    <figure class="Objf TpMvPlay AAIco-play_arrow">
                                        <img src="//pelisimg.online/cover/fake-famous-2-1612612923.jpg" alt="img">
                                    </figure>
                                </div>
                                <div class="Title">Fake Famous</div>
                            </a>
                            <p class="Info">
                                <span class="Date AAIco-date_range">2021</span>
                            </p>
                            </div>
                        </li>
                                                <li>
                            <div class="TPost A">
                            <a href="/9269/fall-in-love-at-first-kiss">
                                <div class="Image">
                                    <figure class="Objf TpMvPlay AAIco-play_arrow">
                                        <img src="//pelisimg.online/cover/fall-in-love-at-first-kiss-2-1588778763.jpg" alt="img">
                                    </figure>
                                </div>
                                <div class="Title">Fall in Love at First Kiss</div>
                            </a>
                            <p class="Info">
                                <span class="Date AAIco-date_range">2019</span>
                            </p>
                            </div>
                        </li>
                                                <li>
                            <div class="TPost A">
                            <a href="/8195/fallen">
                                <div class="Image">
                                    <figure class="Objf TpMvPlay AAIco-play_arrow">
                                        <img src="//pelisimg.online/cover/fallen-1582401906.jpg" alt="img">
                                    </figure>
                                </div>
                                <div class="Title">Fallen</div>
                            </a>
                            <p class="Info">
                                <span class="Date AAIco-date_range">1998</span>
                            </p>
                            </div>
                        </li>
                                                <li>
                            <div class="TPost A">
                            <a href="/20050/fallen-angels-murder-club-friends-to-die-for">
                                <div class="Image">
                                    <figure class="Objf TpMvPlay AAIco-play_arrow">
                                        <img src="//pelisimg.online/cover/fallen-angels-murder-club-friends-to-die-for-1692751521.png" alt="img">
                                    </figure>
                                </div>
                                <div class="Title">Fallen Angels Murder Club: Friends to Die For</div>
                            </a>
                            <p class="Info">
                                <span class="Date AAIco-date_range">2022</span>
                            </p>
                            </div>
                        </li>
                                                <li>
                            <div class="TPost A">
                            <a href="/12231/falling">
                                <div class="Image">
                                    <figure class="Objf TpMvPlay AAIco-play_arrow">
                                        <img src="//pelisimg.online/cover/falling-2-1609127044.jpg" alt="img">
                                    </figure>
                                </div>
                                <div class="Title">Falling</div>
                            </a>
                            <p class="Info">
                                <span class="Date AAIco-date_range">2020</span>
                            </p>
                            </div>
                        </li>
                                                <li>
                            <div class="TPost A">
                            <a href="/2660/falsa-evidencia">
                                <div class="Image">
                                    <figure class="Objf TpMvPlay AAIco-play_arrow">
                                        <img src="//pelisimg.online/cover/falsa-evidencia.jpg" alt="img">
                                    </figure>
                                </div>
                                <div class="Title">Falsa Evidencia</div>
                            </a>
                            <p class="Info">
                                <span class="Date AAIco-date_range">2018</span>
                            </p>
                            </div>
                        </li>
                                                <li>
                            <div class="TPost A">
                            <a href="/12805/faux-semblants">
                                <div class="Image">
                                    <figure class="Objf TpMvPlay AAIco-play_arrow">
                                        <img src="//pelisimg.online/cover/faux-semblants-2-1615260365.jpg" alt="img">
                                    </figure>
                                </div>
                                <div class="Title">Falsas apariencias</div>
                            </a>
                            <p class="Info">
                                <span class="Date AAIco-date_range">2020</span>
                            </p>
                            </div>
                        </li>
                                                <li>
                            <div class="TPost A">
                            <a href="/9509/false-colors">
                                <div class="Image">
                                    <figure class="Objf TpMvPlay AAIco-play_arrow">
                                        <img src="//pelisimg.online/cover/false-colors-1669942689.png" alt="img">
                                    </figure>
                                </div>
                                <div class="Title">False Colors</div>
                            </a>
                            <p class="Info">
                                <span class="Date AAIco-date_range">2020</span>
                            </p>
                            </div>
                        </li>
                                                <li>
                            <div class="TPost A">
                            <a href="/13461/false-hopes">
                                <div class="Image">
                                    <figure class="Objf TpMvPlay AAIco-play_arrow">
                                        <img src="//pelisimg.online/cover/false-hopes-2-1620960723.jpg" alt="img">
                                    </figure>
                                </div>
                                <div class="Title">False Hopes</div>
                            </a>
                            <p class="Info">
                                <span class="Date AAIco-date_range">2020</span>
                            </p>
                            </div>
                        </li>
                                                <li>
                            <div class="TPost A">
                            <a href="/13908/false-positive">
                                <div class="Image">
                                    <figure class="Objf TpMvPlay AAIco-play_arrow">
                                        <img src="//pelisimg.online/cover/false-positive-2-1624766162.jpg" alt="img">
                                    </figure>
                                </div>
                                <div class="Title">False Positive</div>
                            </a>
                            <p class="Info">
                                <span class="Date AAIco-date_range">2021</span>
                            </p>
                            </div>
                        </li>
                                                <li>
                            <div class="TPost A">
                            <a href="/12384/fame-the-musical">
                                <div class="Image">
                                    <figure class="Objf TpMvPlay AAIco-play_arrow">
                                        <img src="//pelisimg.online/cover/fame-the-musical-2-1610513283.jpg" alt="img">
                                    </figure>
                                </div>
                                <div class="Title">Fame: The Musical</div>
                            </a>
                            <p class="Info">
                                <span class="Date AAIco-date_range">2020</span>
                            </p>
                            </div>
                        </li>
                                                <li>
                            <div class="TPost A">
                            <a href="/7755/les-dents-pipi-et-au-lit">
                                <div class="Image">
                                    <figure class="Objf TpMvPlay AAIco-play_arrow">
                                        <img src="//pelisimg.online/cover/les-dents-pipi-et-au-lit-2-1580816042.jpg" alt="img">
                                    </figure>
                                </div>
                                <div class="Title">Familia a la fuerza</div>
                            </a>
                            <p class="Info">
                                <span class="Date AAIco-date_range">2018</span>
                            </p>
                            </div>
                        </li>
                                                <li>
                            <div class="TPost A">
                            <a href="/2442/familia-al-instante">
                                <div class="Image">
                                    <figure class="Objf TpMvPlay AAIco-play_arrow">
                                        <img src="//pelisimg.online/cover/familia-al-instante.jpg" alt="img">
                                    </figure>
                                </div>
                                <div class="Title">Familia al Instante</div>
                            </a>
                            <p class="Info">
                                <span class="Date AAIco-date_range">2018</span>
                            </p>
                            </div>
                        </li>
                                                <li>
                            <div class="TPost A">
                            <a href="/2393/familia-sumergida">
                                <div class="Image">
                                    <figure class="Objf TpMvPlay AAIco-play_arrow">
                                        <img src="//pelisimg.online/cover/familia-sumergida.jpg" alt="img">
                                    </figure>
                                </div>
                                <div class="Title">Familia Sumergida</div>
                            </a>
                            <p class="Info">
                                <span class="Date AAIco-date_range">2018</span>
                            </p>
                            </div>
                        </li>
                                                <li>
                            <div class="TPost A">
                            <a href="/6880/familiye">
                                <div class="Image">
                                    <figure class="Objf TpMvPlay AAIco-play_arrow">
                                        <img src="//pelisimg.online/cover/familiye-2-1575616696.jpg" alt="img">
                                    </figure>
                                </div>
                                <div class="Title">Familiye</div>
                            </a>
                            <p class="Info">
                                <span class="Date AAIco-date_range">2018</span>
                            </p>
                            </div>
                        </li>
                                                <li>
                            <div class="TPost A">
                            <a href="/4885/family">
                                <div class="Image">
                                    <figure class="Objf TpMvPlay AAIco-play_arrow">
                                        <img src="//pelisimg.online/cover/family.jpg" alt="img">
                                    </figure>
                                </div>
                                <div class="Title">Family</div>
                            </a>
                            <p class="Info">
                                <span class="Date AAIco-date_range">2018</span>
                            </p>
                            </div>
                        </li>
                                                <li>
                            <div class="TPost A">
                            <a href="/2644/family-blood">
                                <div class="Image">
                                    <figure class="Objf TpMvPlay AAIco-play_arrow">
                                        <img src="//pelisimg.online/cover/family-blood.jpg" alt="img">
                                    </figure>
                                </div>
                                <div class="Title">Family Blood</div>
                            </a>
                            <p class="Info">
                                <span class="Date AAIco-date_range">2018</span>
                            </p>
                            </div>
                        </li>
                                                <li>
                            <div class="TPost A">
                            <a href="/15118/de-expeditie-van-familie-vos">
                                <div class="Image">
                                    <figure class="Objf TpMvPlay AAIco-play_arrow">
                                        <img src="//pelisimg.online/cover/de-expeditie-van-familie-vos-2-1636247044.jpg" alt="img">
                                    </figure>
                                </div>
                                <div class="Title">Family Fox on Expedition</div>
                            </a>
                            <p class="Info">
                                <span class="Date AAIco-date_range">2020</span>
                            </p>
                            </div>
                        </li>
                                                <li>
                            <div class="TPost A">
                            <a href="/10009/family-romance-llc">
                                <div class="Image">
                                    <figure class="Objf TpMvPlay AAIco-play_arrow">
                                        <img src="//pelisimg.online/cover/family-romance-llc-2-1594257606.jpg" alt="img">
                                    </figure>
                                </div>
                                <div class="Title">Family Romance, LLC</div>
                            </a>
                            <p class="Info">
                                <span class="Date AAIco-date_range">2019</span>
                            </p>
                            </div>
                        </li>
                                                <li>
                            <div class="TPost A">
                            <a href="/5167/fan">
                                <div class="Image">
                                    <figure class="Objf TpMvPlay AAIco-play_arrow">
                                        <img src="//pelisimg.online/cover/fan.jpg" alt="img">
                                    </figure>
                                </div>
                                <div class="Title">Fan</div>
                            </a>
                            <p class="Info">
                                <span class="Date AAIco-date_range">2016</span>
                            </p>
                            </div>
                        </li>
                                                <li>
                            <div class="TPost A">
                            <a href="/19443/fanfik">
                                <div class="Image">
                                    <figure class="Objf TpMvPlay AAIco-play_arrow">
                                        <img src="//pelisimg.online/cover/fanfik-1685096425.png" alt="img">
                                    </figure>
                                </div>
                                <div class="Title">Fanfik</div>
                            </a>
                            <p class="Info">
                                <span class="Date AAIco-date_range">2023</span>
                            </p>
                            </div>
                        </li>
                                                <li>
                            <div class="TPost A">
                            <a href="/12964/fanny-lye-deliverd">
                                <div class="Image">
                                    <figure class="Objf TpMvPlay AAIco-play_arrow">
                                        <img src="//pelisimg.online/cover/fanny-lye-deliverd-2-1616566443.jpg" alt="img">
                                    </figure>
                                </div>
                                <div class="Title">Fanny Lye liberada</div>
                            </a>
                            <p class="Info">
                                <span class="Date AAIco-date_range">2019</span>
                            </p>
                            </div>
                        </li>--%>