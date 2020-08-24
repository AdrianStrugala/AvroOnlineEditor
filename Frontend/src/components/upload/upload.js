import React, { Component } from 'react'
import './upload.css'
import Dropzone from '../dropzone/dropzone.js'

class Upload extends Component {
    constructor(props) {
        super(props);
        this.state = {
            files: [],
            uploading: false,
            uploadProgress: {},
            successfullUploaded: false
        };

        this.onFilesAdded = this.onFilesAdded.bind(this);
        this.uploadFiles = this.uploadFiles.bind(this);
        this.sendRequest = this.sendRequest.bind(this);
        this.renderActions = this.renderActions.bind(this);
    }

    onFilesAdded(files) {
        this.setState(prevState => ({
            files: prevState.files.concat(files)
        }));
    }

    renderActions() {
        if (this.state.successfullUploaded) {
          return (
            <button
              onClick={() =>
                this.setState({ files: [], successfullUploaded: false })
              }
            >
              Clear
            </button>
          );
        } else {
          return (
            <button
              disabled={this.state.files.length < 0 || this.state.uploading}
              onClick={this.uploadFiles}
            >
              Upload
            </button>
          );
        }
      }

      async uploadFiles() {
        this.setState({ uploadProgress: {}, uploading: true });
        const promises = [];
        this.state.files.forEach(file => {
          promises.push(this.sendRequest(file));
        });
        try {
          await Promise.all(promises);
      
          this.setState({ successfullUploaded: true, uploading: false });
        } catch (e) {
          // Not Production ready! Do some error handling here instead...
          this.setState({ successfullUploaded: true, uploading: false });
        }
      }

      sendRequest(file) {
        return new Promise((resolve, reject) => {
          const req = new XMLHttpRequest();
      
          const formData = new FormData();
          formData.append("file", file);
      
          req.open("POST", "http://localhost:5000/conversion/x");
          req.send(formData);
        });
      }

    render() {
        return (
            <div className="Upload">
                <span className="Title">Upload Files</span>
                <div className="Content">
                    <div>
                        <Dropzone
                            onFilesAdded={this.onFilesAdded}
                            disabled={this.state.uploading || this.state.successfullUploaded}
                        />
                    </div>
                    <div className="Files">
                        {this.state.files.map(file => {
                            return (
                                <div key={file.name} className="Row">
                                    <span className="Filename">{file.name}</span>
                                </div>
                            );
                        })}
                    </div>
                </div>
                <div className="Actions">{this.renderActions()}</div>
            </div>
        );
    }
}

export default Upload;