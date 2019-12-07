const fs = require('fs');

function method1() {
    fs.readFile('./input.txt', (err, data) => {
        console.time('method1 - check the floor');
        const input = data.toString();
        const array = input.split("");

        //part 1 - floor number
        const floorUp = array.filter(value => value === "(").length;
        const floorDown = array.filter(value => value === ")").length;
        console.log('floor number', floorUp - floorDown);

        //part 2 - position of the first character that causes him to enter the basement (floor -1)
        let currentFloor = 0;
        let position = 0;
        for (var value of array) {
            position++;
            if (value === "(")
                currentFloor++;
            else
                currentFloor--;

            if (currentFloor === -1)
                break;
        }
        console.log('position', position);
        console.timeEnd('method1 - check the floor');
    });
}

function method2() {
    fs.readFile('./input.txt', (err, data) => {
        console.time('method2 - check the floor');
        const input = data.toString();
        const array = input.split("");

        //part 1 - floor number
        const floorNumber = array.reduce((acc, value) => {
            if (value === "(")
                return ++acc;
            else
                return --acc;
        }, 0)
        console.log('floor number', floorNumber);

        //part 2 - position of the first character that causes him to enter the basement (floor -1)
        let currentFloor = 0;
        let position = 0;
        array.some(value => {
            position++;
            if (value === "(")
                currentFloor++;
            else
                currentFloor--;

            return currentFloor < 0;
        })
        console.log('position', position);
        console.timeEnd('method2 - check the floor');
    });
}

method1();
// method2();