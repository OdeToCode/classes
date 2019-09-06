import { HubConnection } from "./HubConnection";
import { IHttpConnectionOptions } from "./IHttpConnectionOptions";
import { IHubProtocol } from "./IHubProtocol";
import { ILogger, LogLevel } from "./ILogger";
import { HttpTransportType } from "./ITransport";
/** A builder for configuring {@link @aspnet/signalr.HubConnection} instances. */
export declare class HubConnectionBuilder {
    /** Configures console logging for the {@link @aspnet/signalr.HubConnection}.
     *
     * @param {LogLevel} logLevel The minimum level of messages to log. Anything at this level, or a more severe level, will be logged.
     * @returns The {@link @aspnet/signalr.HubConnectionBuilder} instance, for chaining.
     */
    configureLogging(logLevel: LogLevel): HubConnectionBuilder;
    /** Configures custom logging for the {@link @aspnet/signalr.HubConnection}.
     *
     * @param {ILogger} logger An object implementing the {@link @aspnet/signalr.ILogger} interface, which will be used to write all log messages.
     * @returns The {@link @aspnet/signalr.HubConnectionBuilder} instance, for chaining.
     */
    configureLogging(logger: ILogger): HubConnectionBuilder;
    /** Configures custom logging for the {@link @aspnet/signalr.HubConnection}.
     *
     * @param {LogLevel | ILogger} logging An object implementing the {@link @aspnet/signalr.ILogger} interface or {@link @aspnet/signalr.LogLevel}.
     * @returns The {@link @aspnet/signalr.HubConnectionBuilder} instance, for chaining.
     */
    configureLogging(logging: LogLevel | ILogger): HubConnectionBuilder;
    /** Configures the {@link @aspnet/signalr.HubConnection} to use HTTP-based transports to connect to the specified URL.
     *
     * The transport will be selected automatically based on what the server and client support.
     *
     * @param {string} url The URL the connection will use.
     * @returns The {@link @aspnet/signalr.HubConnectionBuilder} instance, for chaining.
     */
    withUrl(url: string): HubConnectionBuilder;
    /** Configures the {@link @aspnet/signalr.HubConnection} to use the specified HTTP-based transport to connect to the specified URL.
     *
     * @param {string} url The URL the connection will use.
     * @param {HttpTransportType} transportType The specific transport to use.
     * @returns The {@link @aspnet/signalr.HubConnectionBuilder} instance, for chaining.
     */
    withUrl(url: string, transportType: HttpTransportType): HubConnectionBuilder;
    /** Configures the {@link @aspnet/signalr.HubConnection} to use HTTP-based transports to connect to the specified URL.
     *
     * @param {string} url The URL the connection will use.
     * @param {IHttpConnectionOptions} options An options object used to configure the connection.
     * @returns The {@link @aspnet/signalr.HubConnectionBuilder} instance, for chaining.
     */
    withUrl(url: string, options: IHttpConnectionOptions): HubConnectionBuilder;
    /** Configures the {@link @aspnet/signalr.HubConnection} to use the specified Hub Protocol.
     *
     * @param {IHubProtocol} protocol The {@link @aspnet/signalr.IHubProtocol} implementation to use.
     */
    withHubProtocol(protocol: IHubProtocol): HubConnectionBuilder;
    /** Creates a {@link @aspnet/signalr.HubConnection} from the configuration options specified in this builder.
     *
     * @returns {HubConnection} The configured {@link @aspnet/signalr.HubConnection}.
     */
    build(): HubConnection;
}
