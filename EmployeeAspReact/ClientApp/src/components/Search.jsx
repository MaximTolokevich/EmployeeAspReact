import React, { Component } from 'react';
export class Search extends Component { 
    constructor(props) {
        super(props);

        let name = props.name;
        let age = props.age;
        let car = props.car;
        this.state = {
            name: name,
            age: age,
            car: car,
            employee:[]
        }

        this.onNameChanged = this.onNameChanged.bind(this);
        this.onAgeChanged = this.onAgeChanged.bind(this);
        this.onCarChanged = this.onCarChanged.bind(this);

    }
    onNameChanged(e) {

        let val = e.target.value;
        this.setState({ name: val})
    }

    onAgeChanged(e) {
        let val = parseInt(e.target.value);
        this.setState({ age: val})
    }

    onCarChanged(e) {
        let val = parseInt(e.target.value);
        this.setState({ car: val })
    }

    handleClick(e) {
        e.preventDefault();
        this.getData();
    }

    render() {

        return (
            <form>
                <input name="name"
                    type="text"
                    placeholder="Name"
                    value={this.state.name}
                    onChange={this.onNameChanged}
                >
                </input>

                <input name="age"
                    type="number"
                    placeholder="age"
                    value={this.state.age}
                    onChange={this.onAgeChanged}
                >
                </input>

                <select name="car" onChange={this.onCarChanged}>
                    <option type="number" value='null'></option>
                    <option type="number" value='1'>bmw</option>
                    <option type="number" value='2'>vw</option>
                    <option type="number" value='3'>skoda</option>
                </select>

                <button type="submit" onClick={(e) => this.handleClick(e)} > Find </button>
                <table className="table table-striped" aria-labelledby="tableLabel">
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Name</th>
                            <th>Age</th>
                            <th>Car</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.employee.map(forecast =>
                            <tr key={forecast.id}>
                                <td>{forecast.id}</td>
                                <td>{forecast.name}</td>
                                <td>{forecast.age}</td>
                                <td>{forecast.car}</td>
                            </tr>
                        )}
                    </tbody>
                </table>
            </form>
        );
    }
    getData() {
        let body = {name:this.state.name, age:this.state.age,car:this.state.car}
        fetch('https://localhost:5001/api/Home/search',
            {
                method: 'post',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(body)
            }).then(response => response.json())
            .then(data => this.setState({ employee: data }));
        
      
    }
}