var ObjectState = {
    Unchanged: 0,
    Added: 1,
    Modified: 2,
    Deleted: 3
};

var patientMapping = {
    'Patients': {
        key: function(patient) {
            return ko.utils.unwrapObservable(patient.PatientId);
        },
        create: function(options) {
            return new PatientViewModel(options.data);
        }

    }
};

PatientViewModel = function(data) {
    var self = this;
    ko.mapping.fromJS(data, patientMapping, self);

    self.flagPatientAsEdited = function() {
        if (self.ObjectState != ObjectState.Added) {
            self.ObjectState(ObjectState.Modified);
        }
        return true;
    };
};

DoctorViewModel = function (data) {
    var self = this;
    ko.mapping.fromJS(data, patientMapping, self);

    self.save = function() {
            $.ajax({
                url: "/Doctor/Save",
                type: "POST",
                data: ko.toJSON(self),
                contentType: "application/json",
                success: function(data) {
                    if (data.doctorViewModel != null)
                        ko.mapping.fromJS(data.doctorViewModel, {}, self);

                    if (data.newLocation != null)
                        window.location = data.newLocation;
                }
            });
    },

        self.flagDoctorAsEdited = function () {
           
            if (self.ObjectState() != ObjectState.Added) {
                self.ObjectState(ObjectState.Modified);
            }
            return true;
        };

    self.addPatient = function() {
        var patient = new PatientViewModel({ PatientId: 0, FirstName: "First", LastName: "Last", Street: "", City: "", State: "", ZipCode: "", PhoneNumber: "", ObjectState: ObjectState.Added });
        self.Patients.push(patient);
    };

    self.deletePatient = function(patient) {
        self.Patients.remove(this);

        if (patient.PatientId() > 0 && self.PatientsToDelete.indexOf(patient.PatientId()) == -1)
            self.PatientsToDelete.push(patient.PatientId());
    };
};