import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SensorsService } from '../../shared/services/sensors.service';
import { MeasurementsService } from '../../shared/services/measurements.service';
import { MeasurementKind, measurementKindToString, Sensor } from '../../shared/models/sensor.model';
import { DeleteButtonComponent } from '../../shared/components/delete-button/delete-button.component';
import { SensorEditorModalComponent } from '../../shared/components/sensors/sensor-editor-modal/sensor-editor-modal.component';
import { mkConfig, generateCsv, download } from "export-to-csv";

@Component({
    selector: 'app-sensor',
    imports: [DeleteButtonComponent, SensorEditorModalComponent],
    templateUrl: './sensor.component.html',
    styleUrl: './sensor.component.scss'
})
export class SensorComponent implements OnInit {
    private route: ActivatedRoute = inject(ActivatedRoute);
    private sensorsService: SensorsService = inject(SensorsService);
    private measurementsService: MeasurementsService = inject(MeasurementsService);

    sensor?: Sensor;
    deviceId?: number;
    sensorId?: number;


    ngOnInit(): void {
        this.route.paramMap.subscribe(params => {
            if (!params.has('deviceId'))
                throw new Error('No device id provided.');
            if (!params.has('sensorId'))
                throw new Error('No sensor id provided.');

            this.deviceId = params.get('deviceId') as unknown as number;
            this.sensorId = params.get('sensorId') as unknown as number;

            this.sensorsService.getById(this.sensorId).subscribe((sensor: Sensor) => {
                this.sensor = sensor;

                this.measurementsService.getBySensorId(sensor.id).subscribe((measurements) => {
                    if (this.sensor) {
                        this.sensor.measurements = measurements;
                    } else {
                        throw new Error('Failed to load sensor measurements');
                    }
                });
            });
        });
    }

    measurementKindToString(kind: MeasurementKind): string {
        return measurementKindToString(kind);
    }

    onSensorChanged(): void {
        this.ngOnInit();
    }

    deleteSensor(sensor: Sensor): void {
        this.sensorsService.delete(sensor).subscribe(() => {
            this.ngOnInit();
        });
    }

    downloadCsv(): void {
        if (!this.sensor)
            throw new Error('Sensor is not defined');
        if (!this.sensor.measurements || this.sensor.measurements.length === 0)
            throw new Error('No measurements available for download');


        const csvData = this.sensor.measurements.map(measurement => ({
            ReceptionTime: measurement.receptionTime,
            MeasurementTime: measurement.measurementTime,
            Value: measurement.value,
        }));

        const csvConfig = mkConfig({ 
            filename: `${this.sensor?.name || 'UnknownSensor'}_Kind: ${measurementKindToString(this.sensor.kind)}_${new Date().toISOString().split('T')[0]}`, 
            useKeysAsHeaders: true 
        });
        const csv = generateCsv(csvConfig)(csvData);

        download(csvConfig)(csv);
    }
}
