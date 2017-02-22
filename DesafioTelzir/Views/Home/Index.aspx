<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head id="Head1" >
    <title>Calcular tarifa</title>
    <link rel="stylesheet" type="text/css" href="../../Style/site.css" />
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/2.0.0/jquery.min.js"></script>
    <script src="<%=Url.Content("~/Scripts/dropdown.js")%>" type="text/javascript"></script>
</head>
<body>
    <div class="page">
    <header class="header">
        <div class="title">
            <h1>Calcular Tarifa</h1><br />
        </div>
        <div class="titleDisplay"></div>
    </header>
    <form id="calculate" >
    <fieldset>
        <legend>1. Selecione DDD de origem e destino</legend>
        <ol>
            <li>
                <label>DDD de origem: </label>
                <select id="drpOrigem" onchange="$.fillDestination()" ></select>
            </li>
            <li>
                <label>DDD de destino: </label>
                <select id="drpDestino"></select>
            </li>
        </ol>
    </fieldset>
    <fieldset>
        <legend>2. Escolha o tipo de plano</legend>
        <ol>
            <li>
                <fieldset>
                <legend></legend>
                <ol>
                    <li>
                        <label><input type="radio" name="rbfalemais" value="30">FaleMais 30</label>
                        <label><input type="radio" name="rbfalemais" value="60">FaleMais 60</label>
                        <label><input type="radio" name="rbfalemais" value="120">FaleMais 120</label>
                    </li>
                </ol>
                </fieldset>
            </li>
        </ol>
    </fieldset>
    <fieldset>
        <legend>3. Digite o tempo de ligação</legend>
        <ol>
            <li>
            <label>Em minutos: </label>
            <input type="number" min="1" max="999999" step="1" id="itminute" name="itminute" placeholder="Ex.: 20" required autofocus
                onkeypress="if ( isNaN(this.value + String.fromCharCode(event.keyCode) ) || this.value.length > 5) return false;" />
            </li>
        </ol>
    </fieldset>
    <fieldset>
        <legend>Calcular</legend>
        <ol>
            <li>
                <input type="button" name="Shareitem" id="Shareitem"  onclick="loadXMLDoc()" value="Calcular" />
            </li>
        </ol>
    </fieldset>
    <fieldset>
        <legend>Total da tarifa</legend>
        <ol>
            <li>
                <label>Valor com FaleMais: $</label>
                <input type="text" name="cfalemais" id="cfalemais" disabled="disabled" placeholder="0,00" />
            </li>
            <li>
                <label>Valor sem FaleMais: $</label>
                <input type="text" name="sfalemais" id="sfalemais" disabled="disabled" placeholder="0,00" />
            </li>
        </ol>
    </fieldset>
    </form>
    </div>
    <footer class="footer">
        Telzir Corp. © 2015
    </footer>
</body>
</html>

