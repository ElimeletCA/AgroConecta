window.generateContratoArrendamiento = (data) => {
    // Extraer jsPDF desde window.jspdf (se asume que se carga vía CDN)
    const { jsPDF } = window.jspdf;
    const doc = new jsPDF();

    // Contenido HTML del contrato, con estilos simples
    const contratoHTML = `
    <div style="font-family: Arial, sans-serif; font-size: 12px; line-height: 1.5;">
      <h2 style="text-align: center;">Contrato de Arrendamiento</h2>
      <p>
        Por el presente documento, <b>${data.propietario}</b>, en adelante "El Arrendador", y <b>${data.arrendatario}</b>, en adelante "El Arrendatario", 
        acuerdan celebrar el presente contrato de arrendamiento, el cual se regirá por las siguientes cláusulas:
      </p>
      <h3>1. Objeto del Contrato</h3>
      <p>
        El Arrendador da en arrendamiento al Arrendatario el terreno ubicado en <b>${data.direccionTerreno}</b>, para su uso exclusivo y en los términos 
        establecidos en este documento. El terreno será destinado para usos <b>agrícolas</b> y <b>ganaderos</b>, conforme a la normativa vigente.
      </p>
      <h3>2. Plazo del Arrendamiento</h3>
      <p>
        El plazo del arrendamiento será de <b>${data.tiempoArrendamiento}</b>. El Arrendatario se compromete a utilizar el terreno de forma adecuada y 
        a cumplir con todas las disposiciones legales aplicables.
      </p>
      <h3>3. Precio y Forma de Pago</h3>
      <p>
        El costo mensual del arrendamiento será de <b>${data.costoMensual}</b>. Dicho monto deberá ser pagado puntualmente al inicio de cada mes. 
        En caso de mora, se aplicará un recargo adicional del 5% sobre el monto adeudado.
      </p>
      <h3>4. Obligaciones del Arrendatario</h3>
      <ul>
        <li>Conservar y mantener en buen estado el terreno arrendado.</li>
        <li>No realizar modificaciones sin autorización escrita del Arrendador.</li>
        <li>Permitir el acceso para inspecciones periódicas, previo aviso.</li>
        <li>Utilizar el terreno exclusivamente para los fines establecidos en este contrato.</li>
      </ul>
      <h3>5. Obligaciones del Arrendador</h3>
      <ul>
        <li>Entregar el terreno en condiciones aptas para el uso convenido.</li>
        <li>Garantizar el disfrute pacífico del terreno durante la vigencia del contrato.</li>
        <li>Realizar reparaciones que sean de su responsabilidad, siempre que no sean producto del mal uso por parte del Arrendatario.</li>
      </ul>
      <h3>6. Condiciones Adicionales</h3>
      <p>
        Cualquier modificación o acuerdo adicional deberá constar por escrito y ser firmado por ambas partes. En caso de incumplimiento de alguna de las obligaciones 
        aquí estipuladas, el Arrendador se reserva el derecho de dar por terminado el contrato de forma inmediata.
      </p>
      <p>
        Ambas partes declaran haber leído y comprendido cada una de las cláusulas del presente contrato, aceptándolas en su totalidad y obligándose a cumplir 
        con lo aquí pactado.
      </p>
      <p style="margin-top: 30px;">
        Firmado en la ciudad a los <b>${data.fecha}</b>.
      </p>
      <br><br>
      <table style="width: 100%; text-align: center;">
        <tr>
          <td style="width: 50%;">
            ___________________________<br>
            <b>Firma del Arrendador</b>
          </td>
          <td style="width: 50%;">
            ___________________________<br>
            <b>Firma del Arrendatario</b>
          </td>
        </tr>
      </table>
    </div>
  `;

    // Utiliza la función html para convertir el contenido HTML en PDF.
    doc.html(contratoHTML, {
        callback: function (doc) {
            doc.save("ContratoArrendamiento.pdf");
        },
        x: 10,
        y: 10,
        width: 190,       // Ancho máximo del contenido en mm (ajustable según tus necesidades)
        windowWidth: 650  // Ancho del viewport para renderizar el HTML
    });
};
