window.generateContratoArrendamiento = (data) => {
    // Extraer jsPDF desde window.jspdf (ya que se carga por CDN)
    const { jsPDF } = window.jspdf;
    const doc = new jsPDF();

    // Título centrado
    doc.setFontSize(16);
    doc.text("Contrato de Arrendamiento", 105, 20, { align: "center" });

    // Configuración de la fuente para el cuerpo del texto
    doc.setFontSize(12);
    let yPos = 30;

    // Texto extenso del contrato
    const contratoText =
        `Por el presente documento, ${data.propietario}, en adelante "El Arrendador", y ${data.arrendatario}, en adelante "El Arrendatario", 
acuerdan celebrar el presente contrato de arrendamiento, el cual se regirá por las siguientes cláusulas:

1. Objeto del Contrato:
El Arrendador da en arrendamiento al Arrendatario el terreno ubicado en ${data.direccionTerreno}, para su uso exclusivo y en los términos 
establecidos en este documento.

2. Plazo del Arrendamiento:
El plazo del arrendamiento será de ${data.tiempoArrendamiento}. El Arrendatario se compromete a utilizar el terreno de forma adecuada 
y conforme a la normativa vigente.

3. Precio y Forma de Pago:
El costo mensual del arrendamiento será de ${data.costoMensual}. Dicho monto deberá ser pagado puntualmente al inicio de cada mes. 
El incumplimiento en el pago podrá dar lugar a la rescisión del presente contrato.

4. Obligaciones del Arrendatario:
   a. Conservar y mantener en buen estado el terreno arrendado.
   b. No realizar modificaciones sin autorización escrita del Arrendador.
   c. Permitir el acceso para inspecciones periódicas, previo aviso.

5. Obligaciones del Arrendador:
   a. Entregar el terreno en condiciones aptas para el uso convenido.
   b. Garantizar el disfrute pacífico del terreno durante la vigencia del contrato.

6. Condiciones Adicionales:
Cualquier modificación o acuerdo adicional deberá constar por escrito y firmado por ambas partes. El Arrendatario acepta que 
en caso de incumplimiento de las obligaciones aquí estipuladas, el Arrendador podrá dar por terminado el contrato de forma inmediata.

Ambas partes declaran haber leído y comprendido cada una de las cláusulas del presente contrato, aceptándolas en su totalidad, 
y se obligan a cumplir con lo aquí pactado.

Firmado en la ciudad a los ${data.fecha}.`;

    // Dividir el texto en líneas que se ajusten al ancho del PDF (ancho aproximado de 170)
    const textLines = doc.splitTextToSize(contratoText, 170);
    doc.text(textLines, 20, yPos);

    // Posicionar las líneas de firma al final del contenido (ajustando la posición vertical según la cantidad de texto)
    let firmaY = 20 + textLines.length * 6; // aproximación: 6 unidades por línea
    if (firmaY < 250) {
        firmaY = 250;
    }
    // Línea para la firma del Arrendador
    doc.text("Firma del Arrendador:", 20, firmaY);
    doc.line(70, firmaY, 140, firmaY); // línea para firmar

    // Línea para la firma del Arrendatario
    doc.text("Firma del Arrendatario:", 20, firmaY + 15);
    doc.line(80, firmaY + 15, 150, firmaY + 15);

    // Guardar el documento
    doc.save("ContratoArrendamiento.pdf");
};
