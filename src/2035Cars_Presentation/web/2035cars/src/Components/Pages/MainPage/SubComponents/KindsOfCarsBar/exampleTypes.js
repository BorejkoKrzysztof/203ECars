const basePath = process.env.PUBLIC_URL + '/Images/ExampleCars'

export const kindsOfCars = [
    {
        Kind : 'Sedan',
        ImagePath : `${basePath}/Tesla_model_S.png`,
        Alt: 'Tesla Model 3',
        Brand : 'Tesla',
        Model : 'Model 3',
        AmountOfPlaces : 5,
        AmountOfDoors : 4,
    },
    {
        Kind : 'Sport',
        ImagePath : `${basePath}/Porsche_Taycan_Turbo.png`,
        Alt: 'Porsche Taycan Turbo',
        Brand : 'Porsche',
        Model : 'Taycan Turbo',
        AmountOfPlaces : 5,
        AmountOfDoors : 4,
    },
    {
        Kind : 'Suv',
        ImagePath : `${basePath}/Ford_Mustang_Mach_E.png`,
        Alt: 'Ford Mustang Mach E',
        Brand : 'Ford',
        Model : 'Mustang Mach E',
        AmountOfPlaces : 5,
        AmountOfDoors : 4,
    },
    {
        Kind : 'Kompakt',
        ImagePath : `${basePath}/Vw_id3.png`,
        Alt: 'Volskwagen Id 3',
        Brand : 'Volkswage',
        Model : 'Id 3',
        AmountOfPlaces : 5,
        AmountOfDoors : 4,
    },
]