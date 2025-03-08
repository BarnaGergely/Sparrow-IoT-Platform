import { Measurement } from "./measurement.model";

export interface Sensor {
    id: number;
    name: string;
    kind: number;
    deviceId: number;
    measurements?: Measurement[];
}
