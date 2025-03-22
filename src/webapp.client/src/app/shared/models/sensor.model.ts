import { Measurement } from "./measurement.model";

export enum MeasurementKind {
    Temperature = 0,
    Boolean = 1,
    Percentage = 2,
    Integer = 3,
}

export function measurementKindToString(kind: MeasurementKind): string {
    switch (kind) {
        case MeasurementKind.Temperature:
            return "Temperature";
        case MeasurementKind.Boolean:
            return "Boolean";
        case MeasurementKind.Percentage:
            return "Percentage";
        case MeasurementKind.Integer:
            return "Integer";
        default:
            throw new Error("Invalid MeasurementKind");
    }
}

export interface Sensor {
    id: number;
    name: string;
    kind: MeasurementKind;
    deviceId: number;
    measurements?: Measurement[];
}
