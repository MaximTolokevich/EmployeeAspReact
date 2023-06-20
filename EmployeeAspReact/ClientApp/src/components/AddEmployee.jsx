import React, { Component } from 'react';

export class Add extends Component {
    static displayName = Add.name
    constructor(props) {
        super(props);

        let name = props.name;
        let age = props.age;
        let car = props.car;
        let isValidName = this.ValidateName(name);
        let isValidAge = this.ValidateAge(age);
        this.state = {
            name: name,
            age: age,
            car: car,
            isValidName: isValidName,
            isValidAge: isValidAge
        }

        this.onNameChanged = this.onNameChanged.bind(this);
        this.onAgeChanged = this.onAgeChanged.bind(this);
        this.onCarChanged = this.onCarChanged.bind(this);
    }

    ValidateAge(age) {
        return  age >= 18 && age <= 99;
        }

    ValidateName(name) {
        let regEx = /^[\p{L}]{1,50}$/u;
        return regEx.test(name);
    }

    onNameChanged(e) {

        let val = e.target.value;
        let isValid = this.ValidateName(val);
        this.setState({name:val, isValidName: isValid})
    }
    
    onAgeChanged(e) {
        let val = parseInt(e.target.value);
        let isValid = this.ValidateAge(val);
        this.setState({ age: val,isValidAge: isValid})
    }
    
    onCarChanged(e) {
        let val = parseInt(e.target.value);
        this.setState({car: val})
    }



    handleClick(e) {
        e.preventDefault()
        let obj = { id: "0", name: this.state.name, age: this.state.age, car: this.state.car === undefined ? 1 : this.state.car };

            if (!this.state.isValidAge) {
                alert("Age should be between 18 and 99");

            } else if (!this.state.isValidName) {

                alert("Name should contain only letters (max length 50, min - 1)")
            } else {

                let body = JSON.stringify(obj);
                fetch('https://localhost:5001/api/Home', {
                    method: 'post',
                    headers: { 'Content-Type': 'application/json' },
                    body: body
                });
            }  
    }

    render() {

        let isValidName = this.ValidateName(this.state.name);
        let isValidAge = this.ValidateAge(this.state.age);
        let nameColor = isValidName === true ? "green" : "red";
        let ageColor = isValidAge === true ? "green" : "red";

        return (
            <form>
                <input name="name"
                    type="text"
                    placeholder="Name"
                    value={this.state.name}
                    onChange={this.onNameChanged}
                    style={{ borderColor:nameColor }}
                    >
                </input>

                <input name="age"
                    type="number"
                    placeholder="age"
                    value={this.state.age}
                    onChange={this.onAgeChanged}
                    style={{ borderColor: ageColor }}
                >
                </input>

                <select name="car" onChange={this.onCarChanged}>
                    <option type="number" value='1'>bmw</option>
                    <option type="number" value='2'>vw</option>
                    <option type="number" value='3'>skoda</option>
                </select>

                <button type="submit" onClick={(e)=>this.handleClick(e)} > Add </button>
            </form>
        );
    }
}