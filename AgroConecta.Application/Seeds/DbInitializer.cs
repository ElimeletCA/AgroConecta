using AgroConecta.Domain.Sistema.General;
using AgroConecta.Domain.Sistema.Tipos;
using AgroConecta.Infrastructure.Repositorios.Data;

namespace AgroConecta.Application.Seeds;

public static class DbInitializer
{
    public static async Task Seed(AppDbContext context)
    {
        // Verificar y sembrar TipoArrendamiento
        if (!context.TipoArrendamientos.Any())
        {
            context.TipoArrendamientos.AddRange(
                new TipoArrendamiento { Id = Guid.NewGuid().ToString(), Descripcion = "Arrendamiento a 1 mes" },
                new TipoArrendamiento { Id = Guid.NewGuid().ToString(), Descripcion = "Arrendamiento a 3 meses" },
                new TipoArrendamiento { Id = Guid.NewGuid().ToString(), Descripcion = "Arrendamiento a 6 meses" },
                new TipoArrendamiento { Id = Guid.NewGuid().ToString(), Descripcion = "Arrendamiento a 1 año" },
                new TipoArrendamiento { Id = Guid.NewGuid().ToString(), Descripcion = "Arrendamiento a 2 años" }
            );
        }

        // Verificar y sembrar TipoCultivo
        if (!context.TipoCultivos.Any())
        {
            context.TipoCultivos.AddRange(
                new TipoCultivo { Id = Guid.NewGuid().ToString(), Descripcion = "Cultivo de maíz" },
                new TipoCultivo { Id = Guid.NewGuid().ToString(), Descripcion = "Cultivo de trigo" },
                new TipoCultivo { Id = Guid.NewGuid().ToString(), Descripcion = "Cultivo de arroz" },
                new TipoCultivo { Id = Guid.NewGuid().ToString(), Descripcion = "Cultivo de papa" },
                new TipoCultivo { Id = Guid.NewGuid().ToString(), Descripcion = "Cultivo de soya" },
                new TipoCultivo { Id = Guid.NewGuid().ToString(), Descripcion = "Cultivo de caña de azúcar" },
                new TipoCultivo { Id = Guid.NewGuid().ToString(), Descripcion = "Cultivo de algodón" },
                new TipoCultivo { Id = Guid.NewGuid().ToString(), Descripcion = "Cultivo de hortalizas" }
            );
        }

        // Verificar y sembrar TipoMedidaArea
        if (!context.TipoMedidaAreas.Any())
        {
            context.TipoMedidaAreas.AddRange(
                new TipoMedidaArea { Id = Guid.NewGuid().ToString(), Descripcion = "Hectárea" },
                new TipoMedidaArea { Id = Guid.NewGuid().ToString(), Descripcion = "Acre" },
                new TipoMedidaArea { Id = Guid.NewGuid().ToString(), Descripcion = "Decárea" },
                new TipoMedidaArea { Id = Guid.NewGuid().ToString(), Descripcion = "Tarea" },
                new TipoMedidaArea { Id = Guid.NewGuid().ToString(), Descripcion = "Are" },
                new TipoMedidaArea { Id = Guid.NewGuid().ToString(), Descripcion = "Metro cuadrado" },
                new TipoMedidaArea { Id = Guid.NewGuid().ToString(), Descripcion = "Kilómetro cuadrado" },
                new TipoMedidaArea { Id = Guid.NewGuid().ToString(), Descripcion = "Manzana" }
            );
        }

        // Verificar y sembrar TipoSuelo
        if (!context.TipoSuelos.Any())
        {
            context.TipoSuelos.AddRange(
                new TipoSuelo { Id = Guid.NewGuid().ToString(), Descripcion = "Arcilloso" },
                new TipoSuelo { Id = Guid.NewGuid().ToString(), Descripcion = "Arenoso" },
                new TipoSuelo { Id = Guid.NewGuid().ToString(), Descripcion = "Franco" },
                new TipoSuelo { Id = Guid.NewGuid().ToString(), Descripcion = "Limóseo" },
                new TipoSuelo { Id = Guid.NewGuid().ToString(), Descripcion = "Calcáreo" },
                new TipoSuelo { Id = Guid.NewGuid().ToString(), Descripcion = "Orgánico" },
                new TipoSuelo { Id = Guid.NewGuid().ToString(), Descripcion = "Pedregoso" }
            );
        }
        // Verificar y sembrar Provincias

        if (!context.Provincias.Any())
        {
            context.Provincias.AddRange(
                new Provincia { Id = "azua-0001-uuid", Descripcion = "Azua", Latitud = 18.45319, Longitud = -70.7349 },
                new Provincia
                    { Id = "bahoruco-0002-uuid", Descripcion = "Bahoruco", Latitud = 18.4863, Longitud = -71.4150 },
                new Provincia
                    { Id = "barahona-0003-uuid", Descripcion = "Barahona", Latitud = 18.20854, Longitud = -71.10077 },
                new Provincia
                    { Id = "dajabon-0004-uuid", Descripcion = "Dajabón", Latitud = 19.54878, Longitud = -71.70829 },
                new Provincia
                    { Id = "duarte-0005-uuid", Descripcion = "Duarte", Latitud = 19.28939, Longitud = -70.25787 },
                new Provincia
                    { Id = "elseibo-0006-uuid", Descripcion = "El Seibo", Latitud = 18.76559, Longitud = -69.03886 },
                new Provincia
                {
                    Id = "eliaspina-0007-uuid", Descripcion = "Elías Piña", Latitud = 18.87667, Longitud = -71.70294
                },
                new Provincia
                    { Id = "espaillat-0008-uuid", Descripcion = "Espaillat", Latitud = 19.62773, Longitud = -70.27799 },
                new Provincia
                {
                    Id = "hatomayor-0009-uuid", Descripcion = "Hato Mayor", Latitud = 18.76216, Longitud = -69.25647
                },
                new Provincia
                {
                    Id = "hermanasmirabal-0010-uuid", Descripcion = "Hermanas Mirabal", Latitud = 19.37350,
                    Longitud = -70.41883
                },
                new Provincia
                {
                    Id = "independencia-0011-uuid", Descripcion = "Independencia", Latitud = 18.48769,
                    Longitud = -71.85150
                },
                new Provincia
                {
                    Id = "laaltagracia-0012-uuid", Descripcion = "La Altagracia", Latitud = 18.61467,
                    Longitud = -68.71714
                },
                new Provincia
                    { Id = "laromana-0013-uuid", Descripcion = "La Romana", Latitud = 18.42241, Longitud = -68.96631 },
                new Provincia
                    { Id = "lavega-0014-uuid", Descripcion = "La Vega", Latitud = 19.22378, Longitud = -70.53276 },
                new Provincia
                {
                    Id = "mariatrinidadsanchez-0015-uuid", Descripcion = "María Trinidad Sánchez", Latitud = 19.36668,
                    Longitud = -69.85113
                },
                new Provincia
                {
                    Id = "monseñornouel-0016-uuid", Descripcion = "Monseñor Nouel", Latitud = 18.92721,
                    Longitud = -70.39728
                },
                new Provincia
                {
                    Id = "montecristi-0017-uuid", Descripcion = "Monte Cristi", Latitud = 19.84992, Longitud = -71.64884
                },
                new Provincia
                {
                    Id = "monteplata-0018-uuid", Descripcion = "Monte Plata", Latitud = 18.80776, Longitud = -69.78479
                },
                new Provincia
                {
                    Id = "pedernales-0019-uuid", Descripcion = "Pedernales", Latitud = 18.03332, Longitud = -71.74310
                },
                new Provincia
                    { Id = "peravia-0020-uuid", Descripcion = "Peravia", Latitud = 18.27941, Longitud = -70.33225 },
                new Provincia
                {
                    Id = "puertoplata-0021-uuid", Descripcion = "Puerto Plata", Latitud = 19.78358, Longitud = -70.67147
                },
                new Provincia
                    { Id = "samana-0022-uuid", Descripcion = "Samaná", Latitud = 19.20266, Longitud = -69.33563 },
                new Provincia
                {
                    Id = "sancristobal-0023-uuid", Descripcion = "San Cristóbal", Latitud = 18.41593,
                    Longitud = -70.11085
                },
                new Provincia
                {
                    Id = "sanjosedeocoa-0024-uuid", Descripcion = "San José de Ocoa", Latitud = 18.54379,
                    Longitud = -70.50703
                },
                new Provincia
                    { Id = "sanjuan-0025-uuid", Descripcion = "San Juan", Latitud = 18.80690, Longitud = -71.23250 },
                new Provincia
                {
                    Id = "sanpedrodemacoris-0026-uuid", Descripcion = "San Pedro de Macorís", Latitud = 18.46374,
                    Longitud = -69.30405
                },
                new Provincia
                {
                    Id = "sanchezramirez-0027-uuid", Descripcion = "Sánchez Ramírez", Latitud = 19.05119,
                    Longitud = -70.14681
                },
                new Provincia
                    { Id = "santiago-0028-uuid", Descripcion = "Santiago", Latitud = 19.45084, Longitud = -70.69472 },
                new Provincia
                {
                    Id = "santiagorodriguez-0029-uuid", Descripcion = "Santiago Rodríguez", Latitud = 19.47912,
                    Longitud = -71.34573
                },
                new Provincia
                {
                    Id = "santodomingo-0030-uuid", Descripcion = "Santo Domingo", Latitud = 18.47769,
                    Longitud = -69.88334
                },
                new Provincia
                    { Id = "valverde-0031-uuid", Descripcion = "Valverde", Latitud = 19.54818, Longitud = -71.08257 },
                new Provincia
                {
                    Id = "distritonacional-0032-uuid", Descripcion = "Distrito Nacional", Latitud = 18.44953,
                    Longitud = -69.97564
                }
            );
        }

        if (!context.Municipios.Any())
        {
            context.Municipios.AddRange(
                // DISTRITO NACIONAL (Provincia: distritonacional-0032-uuid)
                new Municipio
                {
                    Id = "santo-domingo-de-guzman-010100", Descripcion = "Santo Domingo de Guzmán",
                    ProvinciaId = "distritonacional-0032-uuid", Latitud = null, Longitud = null
                },

                // PROVINCIA AZUA (Provincia: azua-0001-uuid)
                new Municipio
                {
                    Id = "azua-020100", Descripcion = "Azua", ProvinciaId = "azua-0001-uuid", Latitud = null,
                    Longitud = null
                },
                new Municipio
                {
                    Id = "las-charcas-020200", Descripcion = "Las Charcas", ProvinciaId = "azua-0001-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "las-yayas-de-viajama-020300", Descripcion = "Las Yayas de Viajama",
                    ProvinciaId = "azua-0001-uuid", Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "padre-las-casas-020400", Descripcion = "Padre Las Casas", ProvinciaId = "azua-0001-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "peralta-020500", Descripcion = "Peralta", ProvinciaId = "azua-0001-uuid", Latitud = null,
                    Longitud = null
                },
                new Municipio
                {
                    Id = "sabana-yegua-020600", Descripcion = "Sabana Yegua", ProvinciaId = "azua-0001-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "pueblo-viejo-020700", Descripcion = "Pueblo Viejo", ProvinciaId = "azua-0001-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "tabara-arriba-020800", Descripcion = "Tábara Arriba", ProvinciaId = "azua-0001-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "guayabal-020900", Descripcion = "Guayabal", ProvinciaId = "azua-0001-uuid", Latitud = null,
                    Longitud = null
                },
                new Municipio
                {
                    Id = "estebania-021000", Descripcion = "Estebanía", ProvinciaId = "azua-0001-uuid", Latitud = null,
                    Longitud = null
                },

                // PROVINCIA BAHORUCO (Provincia: bahoruco-0002-uuid)
                new Municipio
                {
                    Id = "neiba-030001", Descripcion = "Neiba", ProvinciaId = "bahoruco-0002-uuid", Latitud = null,
                    Longitud = null
                },
                new Municipio
                {
                    Id = "galvan-030200", Descripcion = "Galván", ProvinciaId = "bahoruco-0002-uuid", Latitud = null,
                    Longitud = null
                },
                new Municipio
                {
                    Id = "tamayo-030300", Descripcion = "Tamayo", ProvinciaId = "bahoruco-0002-uuid", Latitud = null,
                    Longitud = null
                },
                new Municipio
                {
                    Id = "villa-jaragua-030400", Descripcion = "Villa Jaragua", ProvinciaId = "bahoruco-0002-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "los-rios-030500", Descripcion = "Los Ríos", ProvinciaId = "bahoruco-0002-uuid",
                    Latitud = null, Longitud = null
                },

                // PROVINCIA BARAHONA (Provincia: barahona-0003-uuid)
                new Municipio
                {
                    Id = "barahona-040100", Descripcion = "Barahona", ProvinciaId = "barahona-0003-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "cabral-040200", Descripcion = "Cabral", ProvinciaId = "barahona-0003-uuid", Latitud = null,
                    Longitud = null
                },
                new Municipio
                {
                    Id = "enriquillo-040300", Descripcion = "Enriquillo", ProvinciaId = "barahona-0003-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "paraiso-040400", Descripcion = "Paraíso", ProvinciaId = "barahona-0003-uuid", Latitud = null,
                    Longitud = null
                },
                new Municipio
                {
                    Id = "vicente-noble-040500", Descripcion = "Vicente Noble", ProvinciaId = "barahona-0003-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "el-penon-040600", Descripcion = "El Peñón", ProvinciaId = "barahona-0003-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "la-cienaga-040700", Descripcion = "La Ciénaga", ProvinciaId = "barahona-0003-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "fundacion-040800", Descripcion = "Fundación", ProvinciaId = "barahona-0003-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "las-salinas-040900", Descripcion = "Las Salinas", ProvinciaId = "barahona-0003-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "polo-041000", Descripcion = "Polo", ProvinciaId = "barahona-0003-uuid", Latitud = null,
                    Longitud = null
                },
                new Municipio
                {
                    Id = "jaquimeyes-041100", Descripcion = "Jaquimeyes", ProvinciaId = "barahona-0003-uuid",
                    Latitud = null, Longitud = null
                },

                // PROVINCIA DAJABÓN (Provincia: dajabon-0004-uuid)
                new Municipio
                {
                    Id = "dajabon-050100", Descripcion = "Dajabón", ProvinciaId = "dajabon-0004-uuid", Latitud = null,
                    Longitud = null
                },
                new Municipio
                {
                    Id = "loma-de-cabrera-050200", Descripcion = "Loma de Cabrera", ProvinciaId = "dajabon-0004-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "partido-050300", Descripcion = "Partido", ProvinciaId = "dajabon-0004-uuid", Latitud = null,
                    Longitud = null
                },
                new Municipio
                {
                    Id = "restauracion-050400", Descripcion = "Restauración", ProvinciaId = "dajabon-0004-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "el-pino-050500", Descripcion = "El Pino", ProvinciaId = "dajabon-0004-uuid", Latitud = null,
                    Longitud = null
                },

                // PROVINCIA DUARTE (Provincia: duarte-0005-uuid)
                new Municipio
                {
                    Id = "san-francisco-de-macoris-060100", Descripcion = "San Francisco de Macorís",
                    ProvinciaId = "duarte-0005-uuid", Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "arenoso-060200", Descripcion = "Arenoso", ProvinciaId = "duarte-0005-uuid", Latitud = null,
                    Longitud = null
                },
                new Municipio
                {
                    Id = "castillo-060300", Descripcion = "Castillo", ProvinciaId = "duarte-0005-uuid", Latitud = null,
                    Longitud = null
                },
                new Municipio
                {
                    Id = "pimentel-060400", Descripcion = "Pimentel", ProvinciaId = "duarte-0005-uuid", Latitud = null,
                    Longitud = null
                },
                new Municipio
                {
                    Id = "villa-riva-060500", Descripcion = "Villa Riva", ProvinciaId = "duarte-0005-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "las-guaranas-060600", Descripcion = "Las Guáranas", ProvinciaId = "duarte-0005-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "eugenio-maria-de-hostos-060700", Descripcion = "Eugenio María de Hostos",
                    ProvinciaId = "duarte-0005-uuid", Latitud = null, Longitud = null
                },

                // PROVINCIA ELÍAS PIÑA (Provincia: eliaspina-0007-uuid)
                new Municipio
                {
                    Id = "comendador-070100", Descripcion = "Comendador", ProvinciaId = "eliaspina-0007-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "banica-070200", Descripcion = "Bánica", ProvinciaId = "eliaspina-0007-uuid", Latitud = null,
                    Longitud = null
                },
                new Municipio
                {
                    Id = "el-llano-070300", Descripcion = "El Llano", ProvinciaId = "eliaspina-0007-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "hondo-valle-070400", Descripcion = "Hondo Valle", ProvinciaId = "eliaspina-0007-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "pedro-santana-070500", Descripcion = "Pedro Santana", ProvinciaId = "eliaspina-0007-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "juan-santiago-070600", Descripcion = "Juan Santiago", ProvinciaId = "eliaspina-0007-uuid",
                    Latitud = null, Longitud = null
                },

                // PROVINCIA EL SEIBO (Provincia: elseibo-0006-uuid)
                new Municipio
                {
                    Id = "el-seibo-080100", Descripcion = "El Seibo", ProvinciaId = "elseibo-0006-uuid", Latitud = null,
                    Longitud = null
                },
                new Municipio
                {
                    Id = "miches-080200", Descripcion = "Miches", ProvinciaId = "elseibo-0006-uuid", Latitud = null,
                    Longitud = null
                },

                // PROVINCIA ESPAILLAT (Provincia: espaillat-0008-uuid)
                new Municipio
                {
                    Id = "moca-090100", Descripcion = "Moca", ProvinciaId = "espaillat-0008-uuid", Latitud = null,
                    Longitud = null
                },
                new Municipio
                {
                    Id = "cayetano-germosen-090200", Descripcion = "Cayetano Germosén",
                    ProvinciaId = "espaillat-0008-uuid", Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "gaspar-hernandez-090300", Descripcion = "Gaspar Hernández",
                    ProvinciaId = "espaillat-0008-uuid", Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "jamao-al-norte-090400", Descripcion = "Jamao al Norte", ProvinciaId = "espaillat-0008-uuid",
                    Latitud = null, Longitud = null
                },

                // PROVINCIA INDEPENDENCIA (Provincia: independencia-0011-uuid)
                new Municipio
                {
                    Id = "jimani-100100", Descripcion = "Jimaní", ProvinciaId = "independencia-0011-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "duverge-100200", Descripcion = "Duvergé", ProvinciaId = "independencia-0011-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "la-descubierta-100300", Descripcion = "La Descubierta",
                    ProvinciaId = "independencia-0011-uuid", Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "postrer-rio-100400", Descripcion = "Postrer Río", ProvinciaId = "independencia-0011-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "cristobal-100500", Descripcion = "Cristóbal", ProvinciaId = "independencia-0011-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "mella-100600", Descripcion = "Mella", ProvinciaId = "independencia-0011-uuid", Latitud = null,
                    Longitud = null
                },

                // PROVINCIA LA ALTAGRACIA (Provincia: laaltagracia-0012-uuid)
                new Municipio
                {
                    Id = "higuey-110100", Descripcion = "Higüey", ProvinciaId = "laaltagracia-0012-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "san-rafael-del-yuma-110200", Descripcion = "San Rafael del Yuma",
                    ProvinciaId = "laaltagracia-0012-uuid", Latitud = null, Longitud = null
                },

                // PROVINCIA LA ROMANA (Provincia: laromana-0013-uuid)
                new Municipio
                {
                    Id = "la-romana-120100", Descripcion = "La Romana", ProvinciaId = "laromana-0013-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "guaymate-120200", Descripcion = "Guaymate", ProvinciaId = "laromana-0013-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "villa-hermosa-120300", Descripcion = "Villa Hermosa", ProvinciaId = "laromana-0013-uuid",
                    Latitud = null, Longitud = null
                },

                // PROVINCIA LA VEGA (Provincia: lavega-0014-uuid)
                new Municipio
                {
                    Id = "la-vega-130100", Descripcion = "La Vega", ProvinciaId = "lavega-0014-uuid", Latitud = null,
                    Longitud = null
                },
                new Municipio
                {
                    Id = "constanza-130200", Descripcion = "Constanza", ProvinciaId = "lavega-0014-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "jarabacoa-130300", Descripcion = "Jarabacoa", ProvinciaId = "lavega-0014-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "jima-abajo-130400", Descripcion = "Jima Abajo", ProvinciaId = "lavega-0014-uuid",
                    Latitud = null, Longitud = null
                },

                // PROVINCIA MARÍA TRINIDAD SÁNCHEZ (Provincia: mariatrinidadsanchez-0015-uuid)
                new Municipio
                {
                    Id = "nagua-140100", Descripcion = "Nagua", ProvinciaId = "mariatrinidadsanchez-0015-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "cabrera-140200", Descripcion = "Cabrera", ProvinciaId = "mariatrinidadsanchez-0015-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "el-factor-140300", Descripcion = "El Factor", ProvinciaId = "mariatrinidadsanchez-0015-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "rio-san-juan-140400", Descripcion = "Río San Juan",
                    ProvinciaId = "mariatrinidadsanchez-0015-uuid", Latitud = null, Longitud = null
                },

                // PROVINCIA MONTE CRISTI (Provincia: montecristi-0017-uuid)
                new Municipio
                {
                    Id = "monte-cristi-150100", Descripcion = "Monte Cristi", ProvinciaId = "montecristi-0017-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "castanuelas-150200", Descripcion = "Castañuelas", ProvinciaId = "montecristi-0017-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "guayubin-150300", Descripcion = "Guayubín", ProvinciaId = "montecristi-0017-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "las-matas-de-santa-cruz-150400", Descripcion = "Las Matas de Santa Cruz",
                    ProvinciaId = "montecristi-0017-uuid", Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "pepillo-salcedo-150500", Descripcion = "Pepillo Salcedo",
                    ProvinciaId = "montecristi-0017-uuid", Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "villa-vasquez-150600", Descripcion = "Villa Vásquez", ProvinciaId = "montecristi-0017-uuid",
                    Latitud = null, Longitud = null
                },

                // PROVINCIA PEDERNALES (Provincia: pedernales-0019-uuid)
                new Municipio
                {
                    Id = "pedernales-160100", Descripcion = "Pedernales", ProvinciaId = "pedernales-0019-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "oviedo-160200", Descripcion = "Oviedo", ProvinciaId = "pedernales-0019-uuid", Latitud = null,
                    Longitud = null
                },

                // PROVINCIA PERAVIA (Provincia: peravia-0020-uuid)
                new Municipio
                {
                    Id = "bani-170100", Descripcion = "Baní", ProvinciaId = "peravia-0020-uuid", Latitud = null,
                    Longitud = null
                },
                new Municipio
                {
                    Id = "nizao-170200", Descripcion = "Nizao", ProvinciaId = "peravia-0020-uuid", Latitud = null,
                    Longitud = null
                },
                new Municipio
                {
                    Id = "matanzas-170300", Descripcion = "Matanzas", ProvinciaId = "peravia-0020-uuid", Latitud = null,
                    Longitud = null
                },

                // PROVINCIA PUERTO PLATA (Provincia: puertoplata-0021-uuid)
                new Municipio
                {
                    Id = "puerto-plata-180100", Descripcion = "Puerto Plata", ProvinciaId = "puertoplata-0021-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "altamira-180200", Descripcion = "Altamira", ProvinciaId = "puertoplata-0021-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "guananico-180300", Descripcion = "Guananico", ProvinciaId = "puertoplata-0021-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "imbert-180400", Descripcion = "Imbert", ProvinciaId = "puertoplata-0021-uuid", Latitud = null,
                    Longitud = null
                },
                new Municipio
                {
                    Id = "los-hidalgos-180500", Descripcion = "Los Hidalgos", ProvinciaId = "puertoplata-0021-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "luperon-180600", Descripcion = "Luperón", ProvinciaId = "puertoplata-0021-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "sosua-180700", Descripcion = "Sosúa", ProvinciaId = "puertoplata-0021-uuid", Latitud = null,
                    Longitud = null
                },
                new Municipio
                {
                    Id = "villa-isabela-180800", Descripcion = "Villa Isabela", ProvinciaId = "puertoplata-0021-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "villa-montellano-180900", Descripcion = "Villa Montellano",
                    ProvinciaId = "puertoplata-0021-uuid", Latitud = null, Longitud = null
                },

                // PROVINCIA HERMANAS MIRABAL (Provincia: hermanasmirabal-0010-uuid)
                new Municipio
                {
                    Id = "salcedo-190100", Descripcion = "Salcedo", ProvinciaId = "hermanasmirabal-0010-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "tenares-190200", Descripcion = "Tenares", ProvinciaId = "hermanasmirabal-0010-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "villa-tapia-190300", Descripcion = "Villa Tapia", ProvinciaId = "hermanasmirabal-0010-uuid",
                    Latitud = null, Longitud = null
                },

                // PROVINCIA SAMANÁ (Provincia: samana-0022-uuid)
                new Municipio
                {
                    Id = "samana-200100", Descripcion = "Samaná", ProvinciaId = "samana-0022-uuid", Latitud = null,
                    Longitud = null
                },
                new Municipio
                {
                    Id = "sanchez-200200", Descripcion = "Sánchez", ProvinciaId = "samana-0022-uuid", Latitud = null,
                    Longitud = null
                },
                new Municipio
                {
                    Id = "las-terrenas-200300", Descripcion = "Las Terrenas", ProvinciaId = "samana-0022-uuid",
                    Latitud = null, Longitud = null
                },

                // PROVINCIA SAN CRISTÓBAL (Provincia: sancristobal-0023-uuid)
                new Municipio
                {
                    Id = "san-cristobal-210100", Descripcion = "San Cristóbal", ProvinciaId = "sancristobal-0023-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "sabana-grande-de-palenque-210200", Descripcion = "Sabana Grande de Palenque",
                    ProvinciaId = "sancristobal-0023-uuid", Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "bajos-de-haina-210300", Descripcion = "Bajos de Haina",
                    ProvinciaId = "sancristobal-0023-uuid", Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "cambita-garabitos-210400", Descripcion = "Cambita Garabitos",
                    ProvinciaId = "sancristobal-0023-uuid", Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "villa-altagracia-210500", Descripcion = "Villa Altagracia",
                    ProvinciaId = "sancristobal-0023-uuid", Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "yaguate-210600", Descripcion = "Yaguate", ProvinciaId = "sancristobal-0023-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "san-gregorio-de-nigua-210700", Descripcion = "San Gregorio de Nigua",
                    ProvinciaId = "sancristobal-0023-uuid", Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "los-cacaos-210800", Descripcion = "Los Cacaos", ProvinciaId = "sancristobal-0023-uuid",
                    Latitud = null, Longitud = null
                },

                // PROVINCIA SAN JUAN (Provincia: sanjuan-0025-uuid)
                new Municipio
                {
                    Id = "san-juan-220100", Descripcion = "San Juan", ProvinciaId = "sanjuan-0025-uuid", Latitud = null,
                    Longitud = null
                },
                new Municipio
                {
                    Id = "bohechio-220200", Descripcion = "Bohechío", ProvinciaId = "sanjuan-0025-uuid", Latitud = null,
                    Longitud = null
                },
                new Municipio
                {
                    Id = "el-cercado-220300", Descripcion = "El Cercado", ProvinciaId = "sanjuan-0025-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "juan-de-herrera-220400", Descripcion = "Juan de Herrera", ProvinciaId = "sanjuan-0025-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "las-matas-de-farfan-220500", Descripcion = "Las Matas de Farfán",
                    ProvinciaId = "sanjuan-0025-uuid", Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "vallejuelo-220600", Descripcion = "Vallejuelo", ProvinciaId = "sanjuan-0025-uuid",
                    Latitud = null, Longitud = null
                },

                // PROVINCIA SAN PEDRO DE MACORÍS (Provincia: sanpedrodemacoris-0026-uuid)
                new Municipio
                {
                    Id = "san-pedro-de-macoris-230100", Descripcion = "San Pedro de Macorís",
                    ProvinciaId = "sanpedrodemacoris-0026-uuid", Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "los-llanos-230200", Descripcion = "Los Llanos", ProvinciaId = "sanpedrodemacoris-0026-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "ramon-santana-230300", Descripcion = "Ramón Santana",
                    ProvinciaId = "sanpedrodemacoris-0026-uuid", Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "consuelo-230400", Descripcion = "Consuelo", ProvinciaId = "sanpedrodemacoris-0026-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "quisqueya-230500", Descripcion = "Quisqueya", ProvinciaId = "sanpedrodemacoris-0026-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "guayacanes-230600", Descripcion = "Guayacanes", ProvinciaId = "sanpedrodemacoris-0026-uuid",
                    Latitud = null, Longitud = null
                },

                // PROVINCIA SÁNCHEZ RAMÍREZ (Provincia: schanchezramirez-0027-uuid)
                new Municipio
                {
                    Id = "cotui-240100", Descripcion = "Cotuí", ProvinciaId = "sanchezramirez-0027-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "cevicos-240200", Descripcion = "Cevicos", ProvinciaId = "sanchezramirez-0027-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "fantino-240300", Descripcion = "Fantino", ProvinciaId = "sanchezramirez-0027-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "la-mata-240400", Descripcion = "La Mata", ProvinciaId = "sanchezramirez-0027-uuid",
                    Latitud = null, Longitud = null
                },

                // PROVINCIA SANTIAGO (Provincia: santiago-0028-uuid)
                new Municipio
                {
                    Id = "santiago-250100", Descripcion = "Santiago", ProvinciaId = "santiago-0028-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "bisono-250200", Descripcion = "Bisonó", ProvinciaId = "santiago-0028-uuid", Latitud = null,
                    Longitud = null
                },
                new Municipio
                {
                    Id = "janico-250300", Descripcion = "Jánico", ProvinciaId = "santiago-0028-uuid", Latitud = null,
                    Longitud = null
                },
                new Municipio
                {
                    Id = "licey-al-medio-250400", Descripcion = "Licey al Medio", ProvinciaId = "santiago-0028-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "san-jose-de-las-matas-250500", Descripcion = "San José de las Matas",
                    ProvinciaId = "santiago-0028-uuid", Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "tamboril-250600", Descripcion = "Tamboril", ProvinciaId = "santiago-0028-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "villa-gonzalez-250700", Descripcion = "Villa González", ProvinciaId = "santiago-0028-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "punal-250800", Descripcion = "Puñal", ProvinciaId = "santiago-0028-uuid", Latitud = null,
                    Longitud = null
                },
                new Municipio
                {
                    Id = "sabana-iglesia-250900", Descripcion = "Sabana Iglesia", ProvinciaId = "santiago-0028-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "baitoa-251000", Descripcion = "Baitoa", ProvinciaId = "santiago-0028-uuid", Latitud = null,
                    Longitud = null
                },

                // PROVINCIA SANTIAGO RODRÍGUEZ (Provincia: santiagorodriguez-0029-uuid)
                new Municipio
                {
                    Id = "san-ignacio-de-sabaneta-260100", Descripcion = "San Ignacio de Sabaneta",
                    ProvinciaId = "santiagorodriguez-0029-uuid", Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "villa-los-almacigos-260200", Descripcion = "Villa Los Almácigos",
                    ProvinciaId = "santiagorodriguez-0029-uuid", Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "moncion-260300", Descripcion = "Monción", ProvinciaId = "santiagorodriguez-0029-uuid",
                    Latitud = null, Longitud = null
                },

                // PROVINCIA VALVERDE (Provincia: valverde-0031-uuid)
                new Municipio
                {
                    Id = "mao-270100", Descripcion = "Mao", ProvinciaId = "valverde-0031-uuid", Latitud = null,
                    Longitud = null
                },
                new Municipio
                {
                    Id = "esperanza-270200", Descripcion = "Esperanza", ProvinciaId = "valverde-0031-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "laguna-salada-270300", Descripcion = "Laguna Salada", ProvinciaId = "valverde-0031-uuid",
                    Latitud = null, Longitud = null
                },

                // PROVINCIA MONSEÑOR NOUEL (Provincia: monseñornouel-0016-uuid)
                new Municipio
                {
                    Id = "bonao-280100", Descripcion = "Bonao", ProvinciaId = "monseñornouel-0016-uuid", Latitud = null,
                    Longitud = null
                },
                new Municipio
                {
                    Id = "maimon-280200", Descripcion = "Maimón", ProvinciaId = "monseñornouel-0016-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "piedra-blanca-280300", Descripcion = "Piedra Blanca", ProvinciaId = "monseñornouel-0016-uuid",
                    Latitud = null, Longitud = null
                },

                // PROVINCIA MONTE PLATA (Provincia: monteplata-0018-uuid)
                new Municipio
                {
                    Id = "monte-plata-290100", Descripcion = "Monte Plata", ProvinciaId = "monteplata-0018-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "bayaguana-290200", Descripcion = "Bayaguana", ProvinciaId = "monteplata-0018-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "sabana-grande-de-boya-290300", Descripcion = "Sabana Grande de Boyá",
                    ProvinciaId = "monteplata-0018-uuid", Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "yamasa-290400", Descripcion = "Yamasá", ProvinciaId = "monteplata-0018-uuid", Latitud = null,
                    Longitud = null
                },
                new Municipio
                {
                    Id = "peralvillo-290500", Descripcion = "Peralvillo", ProvinciaId = "monteplata-0018-uuid",
                    Latitud = null, Longitud = null
                },

                // PROVINCIA HATO MAYOR (Provincia: hatomayor-0009-uuid)
                new Municipio
                {
                    Id = "hato-mayor-300100", Descripcion = "Hato Mayor", ProvinciaId = "hatomayor-0009-uuid",
                    Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "sabana-de-la-mar-300200", Descripcion = "Sabana de la Mar",
                    ProvinciaId = "hatomayor-0009-uuid", Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "el-valle-300300", Descripcion = "El Valle", ProvinciaId = "hatomayor-0009-uuid",
                    Latitud = null, Longitud = null
                },

                // PROVINCIA SAN JOSÉ DE OCOA (Provincia: sanjosedeocoa-0024-uuid)
                new Municipio
                {
                    Id = "san-jose-de-ocoa-310100", Descripcion = "San José de Ocoa",
                    ProvinciaId = "sanjosedeocoa-0024-uuid", Latitud = null, Longitud = null
                },
                new Municipio
                {
                    Id = "sabana-larga-310200", Descripcion = "Sabana Larga", ProvinciaId = "sanjosedeocoa-0024-uuid",
                    Latitud = null, Longitud = null
                });
        }
        context.SaveChanges();
    }
}


