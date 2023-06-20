import React, { Component } from 'react';
import { confirmAlert } from 'react-confirm-alert';
import 'react-confirm-alert/src/react-confirm-alert.css';

export class Delete extends Component {
    static displayName = Delete.name
    constructor(props) {
        super(props);
        this.state = {
            name: ""
        }

        this.onNameChanged = this.onNameChanged.bind(this);
        this.submit = this.submit.bind(this);
        this.Delete = this.Delete.bind(this);
    }
    onNameChanged(e) {
        let val = e.target.value;
        this.setState({ name: val });
    }
    Delete(name) {
        fetch('https://localhost:5001/api/Home?name=' + name,
            {
                method: 'delete',
            });
    }

    submit = () => {

        confirmAlert({
            title: 'Confirm to submit',
            message: 'Are you sure to do this.',
            buttons: [
                {
                    label: 'Yes',
                    onClick: () => this.Delete(this.state.name)
                },
                {
                    label: 'No',
                    
                }
            ]
        });
    }
   

    render() {
        
        return (
            <div>
            <input name="name"
                type="text"
                placeholder="enter the name to delete"
                value={this.state.name}
                onChange={this.onNameChanged}
            > 
            </input>
                <button type="submit" onClick={this.submit}>Delete</button>
            </div>
        );
    }

}