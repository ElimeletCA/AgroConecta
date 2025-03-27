window.ReporteTerrenos = (data) => {
    const { jsPDF } = window.jspdf;
    const docReporteTerrenos = new jsPDF();

    docReporteTerrenos.text("Reporte de Terrenos", 14, 10);

    docReporteTerrenos.autoTable({
        head: [['Provincia', 'Municipio', 'Tipo Suelo', 'Cantidad de Área']],
        body: data.map(item => [
            item.descripcionProvincia || '',
            item.descripcionMunicipio || '',
            item.descripcionTipoSuelo ? `Suelo ${item.descripcionTipoSuelo}` : '',
            `${item.cantidadAreaSueloTotal || ''} ${item.descripcionTipoMedidaArea || ''}`
        ]),
        startY: 20
    });

    docReporteTerrenos.save("ReporteTerrenos.pdf");
};

window.ReporteTiposArrendamiento = (data) => {
    const { jsPDF } = window.jspdf;
    const doc = new jsPDF();

    doc.text("Reporte de Tipos de Arrendamiento", 14, 10);

    doc.autoTable({
        head: [['Descripción']],
        body: data.map(item => [
            item.descripcion || ''
           
        ]),
        startY: 20
    });

    doc.save("ReporteTiposArrendamiento.pdf");
};
window.ReporteTiposCultivo = (data) => {
    const { jsPDF } = window.jspdf;
    const doc = new jsPDF();

    doc.text("Reporte de Tipos de Cultivo", 14, 10);

    doc.autoTable({
        head: [['Descripción']],
        body: data.map(item => [
            item.descripcion || ''

        ]),
        startY: 20
    });

    doc.save("ReporteTiposCultivo.pdf");
};
window.ReporteTiposMedidaArea = (data) => {
    const { jsPDF } = window.jspdf;
    const doc = new jsPDF();

    doc.text("Reporte de Tipos de Medida de Área", 14, 10);

    doc.autoTable({
        head: [['Descripción']],
        body: data.map(item => [
            item.descripcion || ''

        ]),
        startY: 20
    });

    doc.save("ReporteTiposMedidaArea.pdf");
};

window.ReporteTiposSuelo = (data) => {
    const { jsPDF } = window.jspdf;
    const doc = new jsPDF();

    doc.text("Reporte de Tipos de Suelo", 14, 10);

    doc.autoTable({
        head: [['Descripción']],
        body: data.map(item => [
            item.descripcion || ''

        ]),
        startY: 20
    });

    doc.save("ReporteTiposSuelo.pdf");
};