/*!
<<<<<<< HEAD
  * Bootstrap v4.6.0 (https://getbootstrap.com/)
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  * Bootstrap v5.1.0 (https://getbootstrap.com/)
========
  * Bootstrap v4.6.0 (https://getbootstrap.com/)
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  * Copyright 2011-2021 The Bootstrap Authors (https://github.com/twbs/bootstrap/graphs/contributors)
  * Licensed under MIT (https://github.com/twbs/bootstrap/blob/main/LICENSE)
  */
(function (global, factory) {
<<<<<<< HEAD
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  typeof exports === 'object' && typeof module !== 'undefined' ? module.exports = factory(require('@popperjs/core')) :
  typeof define === 'function' && define.amd ? define(['@popperjs/core'], factory) :
  (global = typeof globalThis !== 'undefined' ? globalThis : global || self, global.bootstrap = factory(global.Popper));
}(this, (function (Popper) { 'use strict';

  function _interopNamespace(e) {
    if (e && e.__esModule) return e;
    var n = Object.create(null);
    if (e) {
      Object.keys(e).forEach(function (k) {
        if (k !== 'default') {
          var d = Object.getOwnPropertyDescriptor(e, k);
          Object.defineProperty(n, k, d.get ? d : {
            enumerable: true,
            get: function () {
              return e[k];
            }
          });
        }
      });
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('jquery'), require('popper.js')) :
  typeof define === 'function' && define.amd ? define(['exports', 'jquery', 'popper.js'], factory) :
  (global = typeof globalThis !== 'undefined' ? globalThis : global || self, factory(global.bootstrap = {}, global.jQuery, global.Popper));
}(this, (function (exports, $, Popper) { 'use strict';

  function _interopDefaultLegacy (e) { return e && typeof e === 'object' && 'default' in e ? e : { 'default': e }; }

  var $__default = /*#__PURE__*/_interopDefaultLegacy($);
  var Popper__default = /*#__PURE__*/_interopDefaultLegacy(Popper);

  function _defineProperties(target, props) {
    for (var i = 0; i < props.length; i++) {
      var descriptor = props[i];
      descriptor.enumerable = descriptor.enumerable || false;
      descriptor.configurable = true;
      if ("value" in descriptor) descriptor.writable = true;
      Object.defineProperty(target, descriptor.key, descriptor);
<<<<<<< HEAD
    }
  }

  function _createClass(Constructor, protoProps, staticProps) {
    if (protoProps) _defineProperties(Constructor.prototype, protoProps);
    if (staticProps) _defineProperties(Constructor, staticProps);
    return Constructor;
  }

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
    }
    n['default'] = e;
    return Object.freeze(n);
  }

  var Popper__namespace = /*#__PURE__*/_interopNamespace(Popper);

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  /**
   * --------------------------------------------------------------------------
   * Bootstrap (v5.1.0): util/index.js
   * Licensed under MIT (https://github.com/twbs/bootstrap/blob/main/LICENSE)
   * --------------------------------------------------------------------------
   */
  const MAX_UID = 1000000;
  const MILLISECONDS_MULTIPLIER = 1000;
  const TRANSITION_END = 'transitionend'; // Shoutout AngusCroll (https://goo.gl/pxwQGp)

  const toType = obj => {
    if (obj === null || obj === undefined) {
      return `${obj}`;
    }

    return {}.toString.call(obj).match(/\s([a-z]+)/i)[1].toLowerCase();
  };
  /**
   * --------------------------------------------------------------------------
   * Public Util Api
   * --------------------------------------------------------------------------
   */


  const getUID = prefix => {
    do {
      prefix += Math.floor(Math.random() * MAX_UID);
    } while (document.getElementById(prefix));

    return prefix;
  };

  const getSelector = element => {
    let selector = element.getAttribute('data-bs-target');

    if (!selector || selector === '#') {
      let hrefAttr = element.getAttribute('href'); // The only valid content that could double as a selector are IDs or classes,
      // so everything starting with `#` or `.`. If a "real" URL is used as the selector,
      // `document.querySelector` will rightfully complain it is invalid.
      // See https://github.com/twbs/bootstrap/issues/32273

      if (!hrefAttr || !hrefAttr.includes('#') && !hrefAttr.startsWith('.')) {
        return null;
      } // Just in case some CMS puts out a full URL with the anchor appended


      if (hrefAttr.includes('#') && !hrefAttr.startsWith('#')) {
        hrefAttr = `#${hrefAttr.split('#')[1]}`;
      }

      selector = hrefAttr && hrefAttr !== '#' ? hrefAttr.trim() : null;
    }

    return selector;
  };

  const getSelectorFromElement = element => {
    const selector = getSelector(element);

    if (selector) {
      return document.querySelector(selector) ? selector : null;
    }

    return null;
  };

  const getElementFromSelector = element => {
    const selector = getSelector(element);
    return selector ? document.querySelector(selector) : null;
  };

  const getTransitionDurationFromElement = element => {
    if (!element) {
      return 0;
    } // Get transition-duration of the element


    let {
      transitionDuration,
      transitionDelay
    } = window.getComputedStyle(element);
    const floatTransitionDuration = Number.parseFloat(transitionDuration);
    const floatTransitionDelay = Number.parseFloat(transitionDelay); // Return 0 if element or transition duration is not found

    if (!floatTransitionDuration && !floatTransitionDelay) {
      return 0;
    } // If multiple durations are defined, take the first


    transitionDuration = transitionDuration.split(',')[0];
    transitionDelay = transitionDelay.split(',')[0];
    return (Number.parseFloat(transitionDuration) + Number.parseFloat(transitionDelay)) * MILLISECONDS_MULTIPLIER;
  };

  const triggerTransitionEnd = element => {
    element.dispatchEvent(new Event(TRANSITION_END));
  };

  const isElement = obj => {
    if (!obj || typeof obj !== 'object') {
      return false;
    }

    if (typeof obj.jquery !== 'undefined') {
      obj = obj[0];
    }

    return typeof obj.nodeType !== 'undefined';
  };

  const getElement = obj => {
    if (isElement(obj)) {
      // it's a jQuery object or a node element
      return obj.jquery ? obj[0] : obj;
    }

    if (typeof obj === 'string' && obj.length > 0) {
      return document.querySelector(obj);
    }

    return null;
  };

  const typeCheckConfig = (componentName, config, configTypes) => {
    Object.keys(configTypes).forEach(property => {
      const expectedTypes = configTypes[property];
      const value = config[property];
      const valueType = value && isElement(value) ? 'element' : toType(value);

      if (!new RegExp(expectedTypes).test(valueType)) {
        throw new TypeError(`${componentName.toUpperCase()}: Option "${property}" provided type "${valueType}" but expected type "${expectedTypes}".`);
      }
    });
  };

  const isVisible = element => {
    if (!isElement(element) || element.getClientRects().length === 0) {
      return false;
    }

    return getComputedStyle(element).getPropertyValue('visibility') === 'visible';
  };

  const isDisabled = element => {
    if (!element || element.nodeType !== Node.ELEMENT_NODE) {
      return true;
    }

    if (element.classList.contains('disabled')) {
      return true;
    }

    if (typeof element.disabled !== 'undefined') {
      return element.disabled;
    }

    return element.hasAttribute('disabled') && element.getAttribute('disabled') !== 'false';
  };

  const findShadowRoot = element => {
    if (!document.documentElement.attachShadow) {
      return null;
    } // Can find the shadow root otherwise it'll return the document


    if (typeof element.getRootNode === 'function') {
      const root = element.getRootNode();
      return root instanceof ShadowRoot ? root : null;
    }

    if (element instanceof ShadowRoot) {
      return element;
    } // when we don't find a shadow root


    if (!element.parentNode) {
      return null;
    }

    return findShadowRoot(element.parentNode);
  };

  const noop = () => {};
  /**
   * Trick to restart an element's animation
   *
   * @param {HTMLElement} element
   * @return void
   *
   * @see https://www.charistheo.io/blog/2021/02/restart-a-css-animation-with-javascript/#restarting-a-css-animation
   */


  const reflow = element => {
    // eslint-disable-next-line no-unused-expressions
    element.offsetHeight;
  };

  const getjQuery = () => {
    const {
      jQuery
    } = window;

    if (jQuery && !document.body.hasAttribute('data-bs-no-jquery')) {
      return jQuery;
    }

    return null;
  };

  const DOMContentLoadedCallbacks = [];

  const onDOMContentLoaded = callback => {
    if (document.readyState === 'loading') {
      // add listener on the first call when the document is in loading state
      if (!DOMContentLoadedCallbacks.length) {
        document.addEventListener('DOMContentLoaded', () => {
          DOMContentLoadedCallbacks.forEach(callback => callback());
        });
      }

      DOMContentLoadedCallbacks.push(callback);
    } else {
      callback();
    }
  };

  const isRTL = () => document.documentElement.dir === 'rtl';

  const defineJQueryPlugin = plugin => {
    onDOMContentLoaded(() => {
      const $ = getjQuery();
      /* istanbul ignore if */

      if ($) {
        const name = plugin.NAME;
        const JQUERY_NO_CONFLICT = $.fn[name];
        $.fn[name] = plugin.jQueryInterface;
        $.fn[name].Constructor = plugin;

        $.fn[name].noConflict = () => {
          $.fn[name] = JQUERY_NO_CONFLICT;
          return plugin.jQueryInterface;
        };
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  function _extends() {
    _extends = Object.assign || function (target) {
      for (var i = 1; i < arguments.length; i++) {
        var source = arguments[i];

        for (var key in source) {
          if (Object.prototype.hasOwnProperty.call(source, key)) {
            target[key] = source[key];
          }
        }
<<<<<<< HEAD
      }

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
      }
    });
  };

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  const execute = callback => {
    if (typeof callback === 'function') {
      callback();
    }
  };

  const executeAfterTransition = (callback, transitionElement, waitForTransition = true) => {
    if (!waitForTransition) {
      execute(callback);
      return;
    }
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      return target;
    };

    return _extends.apply(this, arguments);
  }
<<<<<<< HEAD

  function _inheritsLoose(subClass, superClass) {
    subClass.prototype = Object.create(superClass.prototype);
    subClass.prototype.constructor = subClass;
    subClass.__proto__ = superClass;
  }

  /**
   * --------------------------------------------------------------------------
   * Bootstrap (v4.6.0): util.js
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

    const durationPadding = 5;
    const emulatedDuration = getTransitionDurationFromElement(transitionElement) + durationPadding;
    let called = false;

    const handler = ({
      target
    }) => {
      if (target !== transitionElement) {
        return;
      }

      called = true;
      transitionElement.removeEventListener(TRANSITION_END, handler);
      execute(callback);
    };

    transitionElement.addEventListener(TRANSITION_END, handler);
    setTimeout(() => {
      if (!called) {
        triggerTransitionEnd(transitionElement);
      }
    }, emulatedDuration);
  };
  /**
   * Return the previous/next element of a list.
   *
   * @param {array} list    The list of elements
   * @param activeElement   The active element
   * @param shouldGetNext   Choose to get next or previous element
   * @param isCycleAllowed
   * @return {Element|elem} The proper element
   */


  const getNextActiveElement = (list, activeElement, shouldGetNext, isCycleAllowed) => {
    let index = list.indexOf(activeElement); // if the element does not exist in the list return an element depending on the direction and if cycle is allowed

    if (index === -1) {
      return list[!shouldGetNext && isCycleAllowed ? list.length - 1 : 0];
    }

    const listLength = list.length;
    index += shouldGetNext ? 1 : -1;

    if (isCycleAllowed) {
      index = (index + listLength) % listLength;
    }

    return list[Math.max(0, Math.min(index, listLength - 1))];
  };

  /**
   * --------------------------------------------------------------------------
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
   * Bootstrap (v5.1.0): dom/event-handler.js
========
   * Bootstrap (v4.6.0): util.js
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
   * Licensed under MIT (https://github.com/twbs/bootstrap/blob/main/LICENSE)
   * --------------------------------------------------------------------------
   */
  /**
   * ------------------------------------------------------------------------
<<<<<<< HEAD
   * Private TransitionEnd Helpers
   * ------------------------------------------------------------------------
   */

  var TRANSITION_END = 'transitionend';
  var MAX_UID = 1000000;
  var MILLISECONDS_MULTIPLIER = 1000; // Shoutout AngusCroll (https://goo.gl/pxwQGp)

=======
   * Constants
   * ------------------------------------------------------------------------
   */

  const namespaceRegex = /[^.]*(?=\..*)\.|.*/;
  const stripNameRegex = /\..*/;
  const stripUidRegex = /::\d+$/;
  const eventRegistry = {}; // Events storage

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  let uidEvent = 1;
  const customEvents = {
    mouseenter: 'mouseover',
    mouseleave: 'mouseout'
  };
  const customEventsRegex = /^(mouseenter|mouseleave)/i;
  const nativeEvents = new Set(['click', 'dblclick', 'mouseup', 'mousedown', 'contextmenu', 'mousewheel', 'DOMMouseScroll', 'mouseover', 'mouseout', 'mousemove', 'selectstart', 'selectend', 'keydown', 'keypress', 'keyup', 'orientationchange', 'touchstart', 'touchmove', 'touchend', 'touchcancel', 'pointerdown', 'pointermove', 'pointerup', 'pointerleave', 'pointercancel', 'gesturestart', 'gesturechange', 'gestureend', 'focus', 'blur', 'change', 'reset', 'select', 'submit', 'focusin', 'focusout', 'load', 'unload', 'beforeunload', 'resize', 'move', 'DOMContentLoaded', 'readystatechange', 'error', 'abort', 'scroll']);
  /**
   * ------------------------------------------------------------------------
   * Private methods
   * ------------------------------------------------------------------------
   */

  function getUidEvent(element, uid) {
    return uid && `${uid}::${uidEvent++}` || element.uidEvent || uidEvent++;
  }

  function getEvent(element) {
    const uid = getUidEvent(element);
    element.uidEvent = uid;
    eventRegistry[uid] = eventRegistry[uid] || {};
    return eventRegistry[uid];
  }

  function bootstrapHandler(element, fn) {
    return function handler(event) {
      event.delegateTarget = element;

      if (handler.oneOff) {
        EventHandler.off(element, event.type, fn);
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  function toType(obj) {
    if (obj === null || typeof obj === 'undefined') {
      return "" + obj;
    }

    return {}.toString.call(obj).match(/\s([a-z]+)/i)[1].toLowerCase();
  }

  function getSpecialTransitionEndEvent() {
    return {
      bindType: TRANSITION_END,
      delegateType: TRANSITION_END,
      handle: function handle(event) {
        if ($__default['default'](event.target).is(this)) {
          return event.handleObj.handler.apply(this, arguments); // eslint-disable-line prefer-rest-params
        }

        return undefined;
<<<<<<< HEAD
      }
    };
  }

  function transitionEndEmulator(duration) {
    var _this = this;

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
      }

      return fn.apply(element, [event]);
    };
  }

  function bootstrapDelegationHandler(element, selector, fn) {
    return function handler(event) {
      const domElements = element.querySelectorAll(selector);

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      for (let {
        target
      } = event; target && target !== this; target = target.parentNode) {
        for (let i = domElements.length; i--;) {
          if (domElements[i] === target) {
            event.delegateTarget = target;

            if (handler.oneOff) {
              // eslint-disable-next-line unicorn/consistent-destructuring
              EventHandler.off(element, event.type, selector, fn);
            }

            return fn.apply(target, [event]);
          }
        }
      } // To please ESLint


      return null;
    };
  }

  function findHandler(events, handler, delegationSelector = null) {
    const uidEventList = Object.keys(events);

    for (let i = 0, len = uidEventList.length; i < len; i++) {
      const event = events[uidEventList[i]];

      if (event.originalHandler === handler && event.delegationSelector === delegationSelector) {
        return event;
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    var called = false;
    $__default['default'](this).one(Util.TRANSITION_END, function () {
      called = true;
    });
    setTimeout(function () {
      if (!called) {
        Util.triggerTransitionEnd(_this);
<<<<<<< HEAD
      }
    }, duration);
    return this;
  }

  function setTransitionEndSupport() {
    $__default['default'].fn.emulateTransitionEnd = transitionEndEmulator;
    $__default['default'].event.special[Util.TRANSITION_END] = getSpecialTransitionEndEvent();
  }
  /**
   * --------------------------------------------------------------------------
   * Public Util Api
   * --------------------------------------------------------------------------
   */


=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
      }
    }

    return null;
  }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  function normalizeParams(originalTypeEvent, handler, delegationFn) {
    const delegation = typeof handler === 'string';
    const originalHandler = delegation ? delegationFn : handler;
    let typeEvent = getTypeEvent(originalTypeEvent);
    const isNative = nativeEvents.has(typeEvent);

    if (!isNative) {
      typeEvent = originalTypeEvent;
    }

    return [delegation, originalHandler, typeEvent];
========
  function setTransitionEndSupport() {
    $__default['default'].fn.emulateTransitionEnd = transitionEndEmulator;
    $__default['default'].event.special[Util.TRANSITION_END] = getSpecialTransitionEndEvent();
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
  }

  function addHandler(element, originalTypeEvent, handler, delegationFn, oneOff) {
    if (typeof originalTypeEvent !== 'string' || !element) {
      return;
    }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    if (!handler) {
      handler = delegationFn;
      delegationFn = null;
    } // in case of mouseenter or mouseleave wrap the handler within a function that checks for its DOM position
    // this prevents the handler from being dispatched the same way as mouseover or mouseout does
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  var Util = {
    TRANSITION_END: 'bsTransitionEnd',
    getUID: function getUID(prefix) {
      do {
        prefix += ~~(Math.random() * MAX_UID); // "~~" acts like a faster Math.floor() here
      } while (document.getElementById(prefix));
<<<<<<< HEAD

      return prefix;
    },
    getSelectorFromElement: function getSelectorFromElement(element) {
      var selector = element.getAttribute('data-target');

      if (!selector || selector === '#') {
        var hrefAttr = element.getAttribute('href');
        selector = hrefAttr && hrefAttr !== '#' ? hrefAttr.trim() : '';
      }

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js


    if (customEventsRegex.test(originalTypeEvent)) {
      const wrapFn = fn => {
        return function (event) {
          if (!event.relatedTarget || event.relatedTarget !== event.delegateTarget && !event.delegateTarget.contains(event.relatedTarget)) {
            return fn.call(this, event);
          }
        };
      };

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      if (delegationFn) {
        delegationFn = wrapFn(delegationFn);
      } else {
        handler = wrapFn(handler);
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      try {
        return document.querySelector(selector) ? selector : null;
      } catch (_) {
        return null;
<<<<<<< HEAD
      }
    },
    getTransitionDurationFromElement: function getTransitionDurationFromElement(element) {
      if (!element) {
        return 0;
      } // Get transition-duration of the element


=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
      }
    }

    const [delegation, originalHandler, typeEvent] = normalizeParams(originalTypeEvent, handler, delegationFn);
    const events = getEvent(element);
    const handlers = events[typeEvent] || (events[typeEvent] = {});
    const previousFn = findHandler(handlers, originalHandler, delegation ? handler : null);

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    if (previousFn) {
      previousFn.oneOff = previousFn.oneOff && oneOff;
      return;
    }
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      var transitionDuration = $__default['default'](element).css('transition-duration');
      var transitionDelay = $__default['default'](element).css('transition-delay');
      var floatTransitionDuration = parseFloat(transitionDuration);
      var floatTransitionDelay = parseFloat(transitionDelay); // Return 0 if element or transition duration is not found
<<<<<<< HEAD

      if (!floatTransitionDuration && !floatTransitionDelay) {
        return 0;
      } // If multiple durations are defined, take the first


=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

    const uid = getUidEvent(originalHandler, originalTypeEvent.replace(namespaceRegex, ''));
    const fn = delegation ? bootstrapDelegationHandler(element, handler, delegationFn) : bootstrapHandler(element, handler);
    fn.delegationSelector = delegation ? handler : null;
    fn.originalHandler = originalHandler;
    fn.oneOff = oneOff;
    fn.uidEvent = uid;
    handlers[uid] = fn;
    element.addEventListener(typeEvent, fn, delegation);
  }

  function removeHandler(element, events, typeEvent, handler, delegationSelector) {
    const fn = findHandler(events[typeEvent], handler, delegationSelector);

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    if (!fn) {
      return;
    }

    element.removeEventListener(typeEvent, fn, Boolean(delegationSelector));
    delete events[typeEvent][fn.uidEvent];
  }

  function removeNamespacedHandlers(element, events, typeEvent, namespace) {
    const storeElementEvent = events[typeEvent] || {};
    Object.keys(storeElementEvent).forEach(handlerKey => {
      if (handlerKey.includes(namespace)) {
        const event = storeElementEvent[handlerKey];
        removeHandler(element, events, typeEvent, event.originalHandler, event.delegationSelector);
      }
    });
  }

  function getTypeEvent(event) {
    // allow to get the native events from namespaced events ('click.bs.button' --> 'click')
    event = event.replace(stripNameRegex, '');
    return customEvents[event] || event;
  }

  const EventHandler = {
    on(element, event, handler, delegationFn) {
      addHandler(element, event, handler, delegationFn, false);
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      transitionDuration = transitionDuration.split(',')[0];
      transitionDelay = transitionDelay.split(',')[0];
      return (parseFloat(transitionDuration) + parseFloat(transitionDelay)) * MILLISECONDS_MULTIPLIER;
    },
    reflow: function reflow(element) {
      return element.offsetHeight;
    },
    triggerTransitionEnd: function triggerTransitionEnd(element) {
      $__default['default'](element).trigger(TRANSITION_END);
    },
    supportsTransitionEnd: function supportsTransitionEnd() {
      return Boolean(TRANSITION_END);
<<<<<<< HEAD
    },
    isElement: function isElement(obj) {
      return (obj[0] || obj).nodeType;
    },
    typeCheckConfig: function typeCheckConfig(componentName, config, configTypes) {
      for (var property in configTypes) {
        if (Object.prototype.hasOwnProperty.call(configTypes, property)) {
          var expectedTypes = configTypes[property];
          var value = config[property];
          var valueType = value && Util.isElement(value) ? 'element' : toType(value);

          if (!new RegExp(expectedTypes).test(valueType)) {
            throw new Error(componentName.toUpperCase() + ": " + ("Option \"" + property + "\" provided type \"" + valueType + "\" ") + ("but expected type \"" + expectedTypes + "\"."));
          }
        }
      }
    },
    findShadowRoot: function findShadowRoot(element) {
      if (!document.documentElement.attachShadow) {
        return null;
      } // Can find the shadow root otherwise it'll return the document


      if (typeof element.getRootNode === 'function') {
        var root = element.getRootNode();
        return root instanceof ShadowRoot ? root : null;
      }

      if (element instanceof ShadowRoot) {
        return element;
      } // when we don't find a shadow root


      if (!element.parentNode) {
        return null;
      }

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
    },

    one(element, event, handler, delegationFn) {
      addHandler(element, event, handler, delegationFn, true);
    },

    off(element, originalTypeEvent, handler, delegationFn) {
      if (typeof originalTypeEvent !== 'string' || !element) {
        return;
      }

      const [delegation, originalHandler, typeEvent] = normalizeParams(originalTypeEvent, handler, delegationFn);
      const inNamespace = typeEvent !== originalTypeEvent;
      const events = getEvent(element);
      const isNamespace = originalTypeEvent.startsWith('.');

      if (typeof originalHandler !== 'undefined') {
        // Simplest case: handler is passed, remove that listener ONLY.
        if (!events || !events[typeEvent]) {
          return;
        }

        removeHandler(element, events, typeEvent, originalHandler, delegation ? handler : null);
        return;
      }

      if (isNamespace) {
        Object.keys(events).forEach(elementEvent => {
          removeNamespacedHandlers(element, events, elementEvent, originalTypeEvent.slice(1));
        });
      }

      const storeElementEvent = events[typeEvent] || {};
      Object.keys(storeElementEvent).forEach(keyHandlers => {
        const handlerKey = keyHandlers.replace(stripUidRegex, '');

        if (!inNamespace || originalTypeEvent.includes(handlerKey)) {
          const event = storeElementEvent[keyHandlers];
          removeHandler(element, events, typeEvent, event.originalHandler, event.delegationSelector);
        }
      });
    },

    trigger(element, event, args) {
      if (typeof event !== 'string' || !element) {
        return null;
      }

      const $ = getjQuery();
      const typeEvent = getTypeEvent(event);
      const inNamespace = event !== typeEvent;
      const isNative = nativeEvents.has(typeEvent);
      let jQueryEvent;
      let bubbles = true;
      let nativeDispatch = true;
      let defaultPrevented = false;
      let evt = null;

      if (inNamespace && $) {
        jQueryEvent = $.Event(event, args);
        $(element).trigger(jQueryEvent);
        bubbles = !jQueryEvent.isPropagationStopped();
        nativeDispatch = !jQueryEvent.isImmediatePropagationStopped();
        defaultPrevented = jQueryEvent.isDefaultPrevented();
      }

      if (isNative) {
        evt = document.createEvent('HTMLEvents');
        evt.initEvent(typeEvent, bubbles, true);
      } else {
        evt = new CustomEvent(event, {
          bubbles,
          cancelable: true
        });
      } // merge custom information in our event


      if (typeof args !== 'undefined') {
        Object.keys(args).forEach(key => {
          Object.defineProperty(evt, key, {
            get() {
              return args[key];
            }

          });
        });
      }

      if (defaultPrevented) {
        evt.preventDefault();
      }

      if (nativeDispatch) {
        element.dispatchEvent(evt);
      }

      if (evt.defaultPrevented && typeof jQueryEvent !== 'undefined') {
        jQueryEvent.preventDefault();
      }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      return evt;
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      return Util.findShadowRoot(element.parentNode);
    },
    jQueryDetection: function jQueryDetection() {
      if (typeof $__default['default'] === 'undefined') {
        throw new TypeError('Bootstrap\'s JavaScript requires jQuery. jQuery must be included before Bootstrap\'s JavaScript.');
      }

      var version = $__default['default'].fn.jquery.split(' ')[0].split('.');
      var minMajor = 1;
      var ltMajor = 2;
      var minMinor = 9;
      var minPatch = 1;
      var maxMajor = 4;

      if (version[0] < ltMajor && version[1] < minMinor || version[0] === minMajor && version[1] === minMinor && version[2] < minPatch || version[0] >= maxMajor) {
        throw new Error('Bootstrap\'s JavaScript requires at least jQuery v1.9.1 but less than v4.0.0');
      }
<<<<<<< HEAD
    }
  };
  Util.jQueryDetection();
  setTransitionEndSupport();
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
    }

  };
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js

  /**
   * --------------------------------------------------------------------------
   * Bootstrap (v5.1.0): dom/data.js
   * Licensed under MIT (https://github.com/twbs/bootstrap/blob/main/LICENSE)
   * --------------------------------------------------------------------------
   */
========
  Util.jQueryDetection();
  setTransitionEndSupport();
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277

  /**
   * ------------------------------------------------------------------------
   * Constants
   * ------------------------------------------------------------------------
   */
<<<<<<< HEAD

=======
  const elementMap = new Map();
  var Data = {
    set(element, key, instance) {
      if (!elementMap.has(element)) {
        elementMap.set(element, new Map());
      }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      const instanceMap = elementMap.get(element); // make it clear we only want one instance per element
      // can be removed later when multiple key/instances are fine to be used

      if (!instanceMap.has(key) && instanceMap.size !== 0) {
        // eslint-disable-next-line no-console
        console.error(`Bootstrap doesn't allow more than one instance per element. Bound instance: ${Array.from(instanceMap.keys())[0]}.`);
        return;
      }

      instanceMap.set(key, instance);
    },
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  var NAME = 'alert';
  var VERSION = '4.6.0';
  var DATA_KEY = 'bs.alert';
  var EVENT_KEY = "." + DATA_KEY;
  var DATA_API_KEY = '.data-api';
  var JQUERY_NO_CONFLICT = $__default['default'].fn[NAME];
  var SELECTOR_DISMISS = '[data-dismiss="alert"]';
  var EVENT_CLOSE = "close" + EVENT_KEY;
  var EVENT_CLOSED = "closed" + EVENT_KEY;
  var EVENT_CLICK_DATA_API = "click" + EVENT_KEY + DATA_API_KEY;
  var CLASS_NAME_ALERT = 'alert';
  var CLASS_NAME_FADE = 'fade';
  var CLASS_NAME_SHOW = 'show';
  /**
   * ------------------------------------------------------------------------
   * Class Definition
   * ------------------------------------------------------------------------
   */

  var Alert = /*#__PURE__*/function () {
    function Alert(element) {
      this._element = element;
    } // Getters
<<<<<<< HEAD


    var _proto = Alert.prototype;

    // Public
    _proto.close = function close(element) {
      var rootElement = this._element;

      if (element) {
        rootElement = this._getRootElement(element);
      }

      var customEvent = this._triggerCloseEvent(rootElement);

      if (customEvent.isDefaultPrevented()) {
        return;
      }

      this._removeElement(rootElement);
    };

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

    get(element, key) {
      if (elementMap.has(element)) {
        return elementMap.get(element).get(key) || null;
      }

      return null;
    },

    remove(element, key) {
      if (!elementMap.has(element)) {
        return;
      }

      const instanceMap = elementMap.get(element);
      instanceMap.delete(key); // free up element references if there are no instances left for an element

      if (instanceMap.size === 0) {
        elementMap.delete(element);
      }
    }

  };

  /**
   * --------------------------------------------------------------------------
   * Bootstrap (v5.1.0): base-component.js
   * Licensed under MIT (https://github.com/twbs/bootstrap/blob/main/LICENSE)
   * --------------------------------------------------------------------------
   */
  /**
   * ------------------------------------------------------------------------
   * Constants
   * ------------------------------------------------------------------------
   */

  const VERSION = '5.1.0';

  class BaseComponent {
    constructor(element) {
      element = getElement(element);

      if (!element) {
        return;
      }

      this._element = element;
      Data.set(this._element, this.constructor.DATA_KEY, this);
    }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    dispose() {
      Data.remove(this._element, this.constructor.DATA_KEY);
      EventHandler.off(this._element, this.constructor.EVENT_KEY);
      Object.getOwnPropertyNames(this).forEach(propertyName => {
        this[propertyName] = null;
      });
    }

    _queueCallback(callback, element, isAnimated = true) {
      executeAfterTransition(callback, element, isAnimated);
    }
    /** Static */


    static getInstance(element) {
      return Data.get(getElement(element), this.DATA_KEY);
    }

    static getOrCreateInstance(element, config = {}) {
      return this.getInstance(element) || new this(element, typeof config === 'object' ? config : null);
    }

    static get VERSION() {
      return VERSION;
    }
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    _proto.dispose = function dispose() {
      $__default['default'].removeData(this._element, DATA_KEY);
      this._element = null;
    } // Private
    ;
<<<<<<< HEAD

    _proto._getRootElement = function _getRootElement(element) {
      var selector = Util.getSelectorFromElement(element);
      var parent = false;

      if (selector) {
        parent = document.querySelector(selector);
      }

      if (!parent) {
        parent = $__default['default'](element).closest("." + CLASS_NAME_ALERT)[0];
      }

      return parent;
    };

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

    static get NAME() {
      throw new Error('You have to implement the static method "NAME", for each component!');
    }

    static get DATA_KEY() {
      return `bs.${this.NAME}`;
    }

    static get EVENT_KEY() {
      return `.${this.DATA_KEY}`;
    }

  }

  /**
   * --------------------------------------------------------------------------
   * Bootstrap (v5.1.0): util/component-functions.js
   * Licensed under MIT (https://github.com/twbs/bootstrap/blob/main/LICENSE)
   * --------------------------------------------------------------------------
   */

  const enableDismissTrigger = (component, method = 'hide') => {
    const clickEvent = `click.dismiss${component.EVENT_KEY}`;
    const name = component.NAME;
    EventHandler.on(document, clickEvent, `[data-bs-dismiss="${name}"]`, function (event) {
      if (['A', 'AREA'].includes(this.tagName)) {
        event.preventDefault();
      }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      if (isDisabled(this)) {
        return;
========
      if (!parent) {
        parent = $__default['default'](element).closest("." + CLASS_NAME_ALERT)[0];
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
      }

      const target = getElementFromSelector(this) || this.closest(`.${name}`);
      const instance = component.getOrCreateInstance(target); // Method argument is left, for Alert and only, as it doesn't implement the 'hide' method

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      instance[method]();
    });
  };

  /**
   * --------------------------------------------------------------------------
   * Bootstrap (v5.1.0): alert.js
   * Licensed under MIT (https://github.com/twbs/bootstrap/blob/main/LICENSE)
   * --------------------------------------------------------------------------
   */
  /**
   * ------------------------------------------------------------------------
   * Constants
   * ------------------------------------------------------------------------
   */

  const NAME$d = 'alert';
  const DATA_KEY$c = 'bs.alert';
  const EVENT_KEY$c = `.${DATA_KEY$c}`;
  const EVENT_CLOSE = `close${EVENT_KEY$c}`;
  const EVENT_CLOSED = `closed${EVENT_KEY$c}`;
  const CLASS_NAME_FADE$5 = 'fade';
  const CLASS_NAME_SHOW$8 = 'show';
  /**
   * ------------------------------------------------------------------------
   * Class Definition
   * ------------------------------------------------------------------------
   */

  class Alert extends BaseComponent {
    // Getters
    static get NAME() {
      return NAME$d;
    } // Public


    close() {
      const closeEvent = EventHandler.trigger(this._element, EVENT_CLOSE);

      if (closeEvent.defaultPrevented) {
        return;
      }
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    _proto._triggerCloseEvent = function _triggerCloseEvent(element) {
      var closeEvent = $__default['default'].Event(EVENT_CLOSE);
      $__default['default'](element).trigger(closeEvent);
      return closeEvent;
    };
<<<<<<< HEAD

    _proto._removeElement = function _removeElement(element) {
      var _this = this;

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

      this._element.classList.remove(CLASS_NAME_SHOW$8);

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      const isAnimated = this._element.classList.contains(CLASS_NAME_FADE$5);

      this._queueCallback(() => this._destroyElement(), this._element, isAnimated);
    } // Private
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      $__default['default'](element).removeClass(CLASS_NAME_SHOW);

      if (!$__default['default'](element).hasClass(CLASS_NAME_FADE)) {
        this._destroyElement(element);
<<<<<<< HEAD

        return;
      }

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js


<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    _destroyElement() {
      this._element.remove();

      EventHandler.trigger(this._element, EVENT_CLOSED);
      this.dispose();
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      var transitionDuration = Util.getTransitionDurationFromElement(element);
      $__default['default'](element).one(Util.TRANSITION_END, function (event) {
        return _this._destroyElement(element, event);
      }).emulateTransitionEnd(transitionDuration);
    };

    _proto._destroyElement = function _destroyElement(element) {
      $__default['default'](element).detach().trigger(EVENT_CLOSED).remove();
<<<<<<< HEAD
    } // Static
    ;

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
    } // Static

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    Alert._jQueryInterface = function _jQueryInterface(config) {
      return this.each(function () {
        var $element = $__default['default'](this);
        var data = $element.data(DATA_KEY);
<<<<<<< HEAD

        if (!data) {
          data = new Alert(this);
          $element.data(DATA_KEY, data);
        }

        if (config === 'close') {
          data[config](this);
        }
      });
    };

    Alert._handleDismiss = function _handleDismiss(alertInstance) {
      return function (event) {
        if (event) {
          event.preventDefault();
        }

        alertInstance.close(this);
      };
    };

    _createClass(Alert, null, [{
      key: "VERSION",
      get: function get() {
        return VERSION;
      }
    }]);

    return Alert;
  }();
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

    static jQueryInterface(config) {
      return this.each(function () {
        const data = Alert.getOrCreateInstance(this);

        if (typeof config !== 'string') {
          return;
        }

        if (data[config] === undefined || config.startsWith('_') || config === 'constructor') {
          throw new TypeError(`No method named "${config}"`);
        }

        data[config](this);
      });
    }

  }
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  /**
   * ------------------------------------------------------------------------
   * Data Api implementation
   * ------------------------------------------------------------------------
   */


<<<<<<< HEAD
  $__default['default'](document).on(EVENT_CLICK_DATA_API, SELECTOR_DISMISS, Alert._handleDismiss(new Alert()));
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  enableDismissTrigger(Alert, 'close');
========
  $__default['default'](document).on(EVENT_CLICK_DATA_API, SELECTOR_DISMISS, Alert._handleDismiss(new Alert()));
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  /**
   * ------------------------------------------------------------------------
   * jQuery
   * ------------------------------------------------------------------------
<<<<<<< HEAD
   */

=======
   * add .Alert to jQuery only if jQuery is present
   */

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  defineJQueryPlugin(Alert);
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  $__default['default'].fn[NAME] = Alert._jQueryInterface;
  $__default['default'].fn[NAME].Constructor = Alert;

  $__default['default'].fn[NAME].noConflict = function () {
    $__default['default'].fn[NAME] = JQUERY_NO_CONFLICT;
    return Alert._jQueryInterface;
  };
<<<<<<< HEAD

  /**
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

  /**
   * --------------------------------------------------------------------------
   * Bootstrap (v5.1.0): button.js
   * Licensed under MIT (https://github.com/twbs/bootstrap/blob/main/LICENSE)
   * --------------------------------------------------------------------------
   */
  /**
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
   * ------------------------------------------------------------------------
   * Constants
   * ------------------------------------------------------------------------
   */

<<<<<<< HEAD
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  const NAME$c = 'button';
  const DATA_KEY$b = 'bs.button';
  const EVENT_KEY$b = `.${DATA_KEY$b}`;
  const DATA_API_KEY$7 = '.data-api';
  const CLASS_NAME_ACTIVE$3 = 'active';
  const SELECTOR_DATA_TOGGLE$5 = '[data-bs-toggle="button"]';
  const EVENT_CLICK_DATA_API$6 = `click${EVENT_KEY$b}${DATA_API_KEY$7}`;
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  var NAME$1 = 'button';
  var VERSION$1 = '4.6.0';
  var DATA_KEY$1 = 'bs.button';
  var EVENT_KEY$1 = "." + DATA_KEY$1;
  var DATA_API_KEY$1 = '.data-api';
  var JQUERY_NO_CONFLICT$1 = $__default['default'].fn[NAME$1];
  var CLASS_NAME_ACTIVE = 'active';
  var CLASS_NAME_BUTTON = 'btn';
  var CLASS_NAME_FOCUS = 'focus';
  var SELECTOR_DATA_TOGGLE_CARROT = '[data-toggle^="button"]';
  var SELECTOR_DATA_TOGGLES = '[data-toggle="buttons"]';
  var SELECTOR_DATA_TOGGLE = '[data-toggle="button"]';
  var SELECTOR_DATA_TOGGLES_BUTTONS = '[data-toggle="buttons"] .btn';
  var SELECTOR_INPUT = 'input:not([type="hidden"])';
  var SELECTOR_ACTIVE = '.active';
  var SELECTOR_BUTTON = '.btn';
  var EVENT_CLICK_DATA_API$1 = "click" + EVENT_KEY$1 + DATA_API_KEY$1;
  var EVENT_FOCUS_BLUR_DATA_API = "focus" + EVENT_KEY$1 + DATA_API_KEY$1 + " " + ("blur" + EVENT_KEY$1 + DATA_API_KEY$1);
  var EVENT_LOAD_DATA_API = "load" + EVENT_KEY$1 + DATA_API_KEY$1;
<<<<<<< HEAD
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  /**
   * ------------------------------------------------------------------------
   * Class Definition
   * ------------------------------------------------------------------------
   */
<<<<<<< HEAD
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js

  class Button extends BaseComponent {
    // Getters
    static get NAME() {
      return NAME$c;
    } // Public

========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277

  var Button = /*#__PURE__*/function () {
    function Button(element) {
      this._element = element;
      this.shouldAvoidTriggerChange = false;
    } // Getters
<<<<<<< HEAD


    var _proto = Button.prototype;

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

    toggle() {
      // Toggle class and sync the `aria-pressed` attribute with the return value of the `.toggle()` method
      this._element.setAttribute('aria-pressed', this._element.classList.toggle(CLASS_NAME_ACTIVE$3));
    } // Static


<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    static jQueryInterface(config) {
      return this.each(function () {
        const data = Button.getOrCreateInstance(this);

        if (config === 'toggle') {
          data[config]();
        }
      });
    }

  }
  /**
   * ------------------------------------------------------------------------
   * Data Api implementation
   * ------------------------------------------------------------------------
   */


  EventHandler.on(document, EVENT_CLICK_DATA_API$6, SELECTOR_DATA_TOGGLE$5, event => {
    event.preventDefault();
    const button = event.target.closest(SELECTOR_DATA_TOGGLE$5);
    const data = Button.getOrCreateInstance(button);
    data.toggle();
  });
  /**
   * ------------------------------------------------------------------------
   * jQuery
   * ------------------------------------------------------------------------
   * add .Button to jQuery only if jQuery is present
   */

  defineJQueryPlugin(Button);
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    // Public
    _proto.toggle = function toggle() {
      var triggerChangeEvent = true;
      var addAriaPressed = true;
      var rootElement = $__default['default'](this._element).closest(SELECTOR_DATA_TOGGLES)[0];

      if (rootElement) {
        var input = this._element.querySelector(SELECTOR_INPUT);

        if (input) {
          if (input.type === 'radio') {
            if (input.checked && this._element.classList.contains(CLASS_NAME_ACTIVE)) {
              triggerChangeEvent = false;
            } else {
              var activeElement = rootElement.querySelector(SELECTOR_ACTIVE);

              if (activeElement) {
                $__default['default'](activeElement).removeClass(CLASS_NAME_ACTIVE);
              }
            }
          }

          if (triggerChangeEvent) {
            // if it's not a radio button or checkbox don't add a pointless/invalid checked property to the input
            if (input.type === 'checkbox' || input.type === 'radio') {
              input.checked = !this._element.classList.contains(CLASS_NAME_ACTIVE);
            }

            if (!this.shouldAvoidTriggerChange) {
              $__default['default'](input).trigger('change');
            }
          }
<<<<<<< HEAD

          input.focus();
          addAriaPressed = false;
        }
      }

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

  /**
   * --------------------------------------------------------------------------
   * Bootstrap (v5.1.0): dom/manipulator.js
   * Licensed under MIT (https://github.com/twbs/bootstrap/blob/main/LICENSE)
   * --------------------------------------------------------------------------
   */
  function normalizeData(val) {
    if (val === 'true') {
      return true;
    }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    if (val === 'false') {
      return false;
    }

    if (val === Number(val).toString()) {
      return Number(val);
    }

    if (val === '' || val === 'null') {
      return null;
    }

    return val;
  }

  function normalizeDataKey(key) {
    return key.replace(/[A-Z]/g, chr => `-${chr.toLowerCase()}`);
  }

  const Manipulator = {
    setDataAttribute(element, key, value) {
      element.setAttribute(`data-bs-${normalizeDataKey(key)}`, value);
    },

    removeDataAttribute(element, key) {
      element.removeAttribute(`data-bs-${normalizeDataKey(key)}`);
    },
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      if (!(this._element.hasAttribute('disabled') || this._element.classList.contains('disabled'))) {
        if (addAriaPressed) {
          this._element.setAttribute('aria-pressed', !this._element.classList.contains(CLASS_NAME_ACTIVE));
        }

        if (triggerChangeEvent) {
          $__default['default'](this._element).toggleClass(CLASS_NAME_ACTIVE);
        }
      }
    };

    _proto.dispose = function dispose() {
      $__default['default'].removeData(this._element, DATA_KEY$1);
      this._element = null;
    } // Static
    ;

    Button._jQueryInterface = function _jQueryInterface(config, avoidTriggerChange) {
      return this.each(function () {
        var $element = $__default['default'](this);
        var data = $element.data(DATA_KEY$1);

        if (!data) {
          data = new Button(this);
          $element.data(DATA_KEY$1, data);
        }

        data.shouldAvoidTriggerChange = avoidTriggerChange;

        if (config === 'toggle') {
          data[config]();
        }
      });
    };
<<<<<<< HEAD

    _createClass(Button, null, [{
      key: "VERSION",
      get: function get() {
        return VERSION$1;
      }
    }]);

    return Button;
  }();
  /**
   * ------------------------------------------------------------------------
   * Data Api implementation
   * ------------------------------------------------------------------------
   */


=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

    getDataAttributes(element) {
      if (!element) {
        return {};
      }

      const attributes = {};
      Object.keys(element.dataset).filter(key => key.startsWith('bs')).forEach(key => {
        let pureKey = key.replace(/^bs/, '');
        pureKey = pureKey.charAt(0).toLowerCase() + pureKey.slice(1, pureKey.length);
        attributes[pureKey] = normalizeData(element.dataset[key]);
      });
      return attributes;
    },

    getDataAttribute(element, key) {
      return normalizeData(element.getAttribute(`data-bs-${normalizeDataKey(key)}`));
    },

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    offset(element) {
      const rect = element.getBoundingClientRect();
      return {
        top: rect.top + window.pageYOffset,
        left: rect.left + window.pageXOffset
      };
    },

    position(element) {
      return {
        top: element.offsetTop,
        left: element.offsetLeft
      };
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  $__default['default'](document).on(EVENT_CLICK_DATA_API$1, SELECTOR_DATA_TOGGLE_CARROT, function (event) {
    var button = event.target;
    var initialButton = button;

    if (!$__default['default'](button).hasClass(CLASS_NAME_BUTTON)) {
      button = $__default['default'](button).closest(SELECTOR_BUTTON)[0];
    }

    if (!button || button.hasAttribute('disabled') || button.classList.contains('disabled')) {
      event.preventDefault(); // work around Firefox bug #1540995
    } else {
      var inputBtn = button.querySelector(SELECTOR_INPUT);

      if (inputBtn && (inputBtn.hasAttribute('disabled') || inputBtn.classList.contains('disabled'))) {
        event.preventDefault(); // work around Firefox bug #1540995

        return;
      }

      if (initialButton.tagName === 'INPUT' || button.tagName !== 'LABEL') {
        Button._jQueryInterface.call($__default['default'](button), 'toggle', initialButton.tagName === 'INPUT');
      }
<<<<<<< HEAD
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    }
  }).on(EVENT_FOCUS_BLUR_DATA_API, SELECTOR_DATA_TOGGLE_CARROT, function (event) {
    var button = $__default['default'](event.target).closest(SELECTOR_BUTTON)[0];
    $__default['default'](button).toggleClass(CLASS_NAME_FOCUS, /^focus(in)?$/.test(event.type));
  });
  $__default['default'](window).on(EVENT_LOAD_DATA_API, function () {
    // ensure correct active class is set to match the controls' actual values/states
    // find all checkboxes/readio buttons inside data-toggle groups
    var buttons = [].slice.call(document.querySelectorAll(SELECTOR_DATA_TOGGLES_BUTTONS));

    for (var i = 0, len = buttons.length; i < len; i++) {
      var button = buttons[i];
      var input = button.querySelector(SELECTOR_INPUT);

      if (input.checked || input.hasAttribute('checked')) {
        button.classList.add(CLASS_NAME_ACTIVE);
      } else {
        button.classList.remove(CLASS_NAME_ACTIVE);
      }
    } // find all button toggles


    buttons = [].slice.call(document.querySelectorAll(SELECTOR_DATA_TOGGLE));

    for (var _i = 0, _len = buttons.length; _i < _len; _i++) {
      var _button = buttons[_i];

<<<<<<< HEAD
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  };

========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      if (_button.getAttribute('aria-pressed') === 'true') {
        _button.classList.add(CLASS_NAME_ACTIVE);
      } else {
        _button.classList.remove(CLASS_NAME_ACTIVE);
      }
    }
  });
<<<<<<< HEAD
  /**
   * ------------------------------------------------------------------------
   * jQuery
   * ------------------------------------------------------------------------
   */

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
  /**
   * --------------------------------------------------------------------------
   * Bootstrap (v5.1.0): dom/selector-engine.js
   * Licensed under MIT (https://github.com/twbs/bootstrap/blob/main/LICENSE)
   * --------------------------------------------------------------------------
   */
  const NODE_TEXT = 3;
  const SelectorEngine = {
    find(selector, element = document.documentElement) {
      return [].concat(...Element.prototype.querySelectorAll.call(element, selector));
    },

    findOne(selector, element = document.documentElement) {
      return Element.prototype.querySelector.call(element, selector);
    },

    children(element, selector) {
      return [].concat(...element.children).filter(child => child.matches(selector));
    },

    parents(element, selector) {
      const parents = [];
      let ancestor = element.parentNode;

      while (ancestor && ancestor.nodeType === Node.ELEMENT_NODE && ancestor.nodeType !== NODE_TEXT) {
        if (ancestor.matches(selector)) {
          parents.push(ancestor);
        }

        ancestor = ancestor.parentNode;
      }

      return parents;
    },

    prev(element, selector) {
      let previous = element.previousElementSibling;

      while (previous) {
        if (previous.matches(selector)) {
          return [previous];
        }

        previous = previous.previousElementSibling;
      }

      return [];
    },

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    next(element, selector) {
      let next = element.nextElementSibling;

      while (next) {
        if (next.matches(selector)) {
          return [next];
        }

        next = next.nextElementSibling;
      }

      return [];
    },

    focusableChildren(element) {
      const focusables = ['a', 'button', 'input', 'textarea', 'select', 'details', '[tabindex]', '[contenteditable="true"]'].map(selector => `${selector}:not([tabindex^="-"])`).join(', ');
      return this.find(focusables, element).filter(el => !isDisabled(el) && isVisible(el));
    }

========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  $__default['default'].fn[NAME$1] = Button._jQueryInterface;
  $__default['default'].fn[NAME$1].Constructor = Button;

  $__default['default'].fn[NAME$1].noConflict = function () {
    $__default['default'].fn[NAME$1] = JQUERY_NO_CONFLICT$1;
    return Button._jQueryInterface;
<<<<<<< HEAD
  };

  /**
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
  };

  /**
   * --------------------------------------------------------------------------
   * Bootstrap (v5.1.0): carousel.js
   * Licensed under MIT (https://github.com/twbs/bootstrap/blob/main/LICENSE)
   * --------------------------------------------------------------------------
   */
  /**
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
   * ------------------------------------------------------------------------
   * Constants
   * ------------------------------------------------------------------------
   */

<<<<<<< HEAD
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  const NAME$b = 'carousel';
  const DATA_KEY$a = 'bs.carousel';
  const EVENT_KEY$a = `.${DATA_KEY$a}`;
  const DATA_API_KEY$6 = '.data-api';
  const ARROW_LEFT_KEY = 'ArrowLeft';
  const ARROW_RIGHT_KEY = 'ArrowRight';
  const TOUCHEVENT_COMPAT_WAIT = 500; // Time for mouse compat events to fire after touch
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  var NAME$2 = 'carousel';
  var VERSION$2 = '4.6.0';
  var DATA_KEY$2 = 'bs.carousel';
  var EVENT_KEY$2 = "." + DATA_KEY$2;
  var DATA_API_KEY$2 = '.data-api';
  var JQUERY_NO_CONFLICT$2 = $__default['default'].fn[NAME$2];
  var ARROW_LEFT_KEYCODE = 37; // KeyboardEvent.which value for left arrow key
<<<<<<< HEAD

  var ARROW_RIGHT_KEYCODE = 39; // KeyboardEvent.which value for right arrow key

  var TOUCHEVENT_COMPAT_WAIT = 500; // Time for mouse compat events to fire after touch

  var SWIPE_THRESHOLD = 40;
  var Default = {
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

  const SWIPE_THRESHOLD = 40;
  const Default$a = {
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    interval: 5000,
    keyboard: true,
    slide: false,
    pause: 'hover',
    wrap: true,
    touch: true
  };
<<<<<<< HEAD
  var DefaultType = {
=======
  const DefaultType$a = {
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    interval: '(number|boolean)',
    keyboard: 'boolean',
    slide: '(boolean|string)',
    pause: '(string|boolean)',
    wrap: 'boolean',
    touch: 'boolean'
  };
<<<<<<< HEAD
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  const ORDER_NEXT = 'next';
  const ORDER_PREV = 'prev';
  const DIRECTION_LEFT = 'left';
  const DIRECTION_RIGHT = 'right';
  const KEY_TO_DIRECTION = {
    [ARROW_LEFT_KEY]: DIRECTION_RIGHT,
    [ARROW_RIGHT_KEY]: DIRECTION_LEFT
  };
  const EVENT_SLIDE = `slide${EVENT_KEY$a}`;
  const EVENT_SLID = `slid${EVENT_KEY$a}`;
  const EVENT_KEYDOWN = `keydown${EVENT_KEY$a}`;
  const EVENT_MOUSEENTER = `mouseenter${EVENT_KEY$a}`;
  const EVENT_MOUSELEAVE = `mouseleave${EVENT_KEY$a}`;
  const EVENT_TOUCHSTART = `touchstart${EVENT_KEY$a}`;
  const EVENT_TOUCHMOVE = `touchmove${EVENT_KEY$a}`;
  const EVENT_TOUCHEND = `touchend${EVENT_KEY$a}`;
  const EVENT_POINTERDOWN = `pointerdown${EVENT_KEY$a}`;
  const EVENT_POINTERUP = `pointerup${EVENT_KEY$a}`;
  const EVENT_DRAG_START = `dragstart${EVENT_KEY$a}`;
  const EVENT_LOAD_DATA_API$2 = `load${EVENT_KEY$a}${DATA_API_KEY$6}`;
  const EVENT_CLICK_DATA_API$5 = `click${EVENT_KEY$a}${DATA_API_KEY$6}`;
  const CLASS_NAME_CAROUSEL = 'carousel';
  const CLASS_NAME_ACTIVE$2 = 'active';
  const CLASS_NAME_SLIDE = 'slide';
  const CLASS_NAME_END = 'carousel-item-end';
  const CLASS_NAME_START = 'carousel-item-start';
  const CLASS_NAME_NEXT = 'carousel-item-next';
  const CLASS_NAME_PREV = 'carousel-item-prev';
  const CLASS_NAME_POINTER_EVENT = 'pointer-event';
  const SELECTOR_ACTIVE$1 = '.active';
  const SELECTOR_ACTIVE_ITEM = '.active.carousel-item';
  const SELECTOR_ITEM = '.carousel-item';
  const SELECTOR_ITEM_IMG = '.carousel-item img';
  const SELECTOR_NEXT_PREV = '.carousel-item-next, .carousel-item-prev';
  const SELECTOR_INDICATORS = '.carousel-indicators';
  const SELECTOR_INDICATOR = '[data-bs-target]';
  const SELECTOR_DATA_SLIDE = '[data-bs-slide], [data-bs-slide-to]';
  const SELECTOR_DATA_RIDE = '[data-bs-ride="carousel"]';
  const POINTER_TYPE_TOUCH = 'touch';
  const POINTER_TYPE_PEN = 'pen';
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  var DIRECTION_NEXT = 'next';
  var DIRECTION_PREV = 'prev';
  var DIRECTION_LEFT = 'left';
  var DIRECTION_RIGHT = 'right';
  var EVENT_SLIDE = "slide" + EVENT_KEY$2;
  var EVENT_SLID = "slid" + EVENT_KEY$2;
  var EVENT_KEYDOWN = "keydown" + EVENT_KEY$2;
  var EVENT_MOUSEENTER = "mouseenter" + EVENT_KEY$2;
  var EVENT_MOUSELEAVE = "mouseleave" + EVENT_KEY$2;
  var EVENT_TOUCHSTART = "touchstart" + EVENT_KEY$2;
  var EVENT_TOUCHMOVE = "touchmove" + EVENT_KEY$2;
  var EVENT_TOUCHEND = "touchend" + EVENT_KEY$2;
  var EVENT_POINTERDOWN = "pointerdown" + EVENT_KEY$2;
  var EVENT_POINTERUP = "pointerup" + EVENT_KEY$2;
  var EVENT_DRAG_START = "dragstart" + EVENT_KEY$2;
  var EVENT_LOAD_DATA_API$1 = "load" + EVENT_KEY$2 + DATA_API_KEY$2;
  var EVENT_CLICK_DATA_API$2 = "click" + EVENT_KEY$2 + DATA_API_KEY$2;
  var CLASS_NAME_CAROUSEL = 'carousel';
  var CLASS_NAME_ACTIVE$1 = 'active';
  var CLASS_NAME_SLIDE = 'slide';
  var CLASS_NAME_RIGHT = 'carousel-item-right';
  var CLASS_NAME_LEFT = 'carousel-item-left';
  var CLASS_NAME_NEXT = 'carousel-item-next';
  var CLASS_NAME_PREV = 'carousel-item-prev';
  var CLASS_NAME_POINTER_EVENT = 'pointer-event';
  var SELECTOR_ACTIVE$1 = '.active';
  var SELECTOR_ACTIVE_ITEM = '.active.carousel-item';
  var SELECTOR_ITEM = '.carousel-item';
  var SELECTOR_ITEM_IMG = '.carousel-item img';
  var SELECTOR_NEXT_PREV = '.carousel-item-next, .carousel-item-prev';
  var SELECTOR_INDICATORS = '.carousel-indicators';
  var SELECTOR_DATA_SLIDE = '[data-slide], [data-slide-to]';
  var SELECTOR_DATA_RIDE = '[data-ride="carousel"]';
  var PointerType = {
    TOUCH: 'touch',
    PEN: 'pen'
  };
<<<<<<< HEAD
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  /**
   * ------------------------------------------------------------------------
   * Class Definition
   * ------------------------------------------------------------------------
   */

<<<<<<< HEAD
  var Carousel = /*#__PURE__*/function () {
    function Carousel(element, config) {
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  class Carousel extends BaseComponent {
    constructor(element, config) {
      super(element);
========
  var Carousel = /*#__PURE__*/function () {
    function Carousel(element, config) {
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      this._items = null;
      this._interval = null;
      this._activeElement = null;
      this._isPaused = false;
      this._isSliding = false;
      this.touchTimeout = null;
      this.touchStartX = 0;
      this.touchDeltaX = 0;
      this._config = this._getConfig(config);
<<<<<<< HEAD
      this._element = element;
      this._indicatorsElement = this._element.querySelector(SELECTOR_INDICATORS);
      this._touchSupported = 'ontouchstart' in document.documentElement || navigator.maxTouchPoints > 0;
      this._pointerEvent = Boolean(window.PointerEvent || window.MSPointerEvent);
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      this._indicatorsElement = SelectorEngine.findOne(SELECTOR_INDICATORS, this._element);
========
      this._element = element;
      this._indicatorsElement = this._element.querySelector(SELECTOR_INDICATORS);
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
      this._touchSupported = 'ontouchstart' in document.documentElement || navigator.maxTouchPoints > 0;
      this._pointerEvent = Boolean(window.PointerEvent);
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277

      this._addEventListeners();
    } // Getters


<<<<<<< HEAD
    var _proto = Carousel.prototype;

=======
    static get Default() {
      return Default$a;
    }

    static get NAME() {
      return NAME$b;
    } // Public

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js

    next() {
      this._slide(ORDER_NEXT);
    }

    nextWhenVisible() {
      // Don't call next when the page isn't visible
      // or the carousel or its parent isn't visible
      if (!document.hidden && isVisible(this._element)) {
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    // Public
    _proto.next = function next() {
      if (!this._isSliding) {
        this._slide(DIRECTION_NEXT);
      }
    };

    _proto.nextWhenVisible = function nextWhenVisible() {
      var $element = $__default['default'](this._element); // Don't call next when the page isn't visible
      // or the carousel or its parent isn't visible

      if (!document.hidden && $element.is(':visible') && $element.css('visibility') !== 'hidden') {
<<<<<<< HEAD
        this.next();
      }
    };

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
        this.next();
      }
    }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    prev() {
      this._slide(ORDER_PREV);
    }
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    _proto.prev = function prev() {
      if (!this._isSliding) {
        this._slide(DIRECTION_PREV);
      }
    };
<<<<<<< HEAD

    _proto.pause = function pause(event) {
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

    pause(event) {
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      if (!event) {
        this._isPaused = true;
      }

<<<<<<< HEAD
      if (this._element.querySelector(SELECTOR_NEXT_PREV)) {
        Util.triggerTransitionEnd(this._element);
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      if (SelectorEngine.findOne(SELECTOR_NEXT_PREV, this._element)) {
        triggerTransitionEnd(this._element);
========
      if (this._element.querySelector(SELECTOR_NEXT_PREV)) {
        Util.triggerTransitionEnd(this._element);
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
        this.cycle(true);
      }

      clearInterval(this._interval);
      this._interval = null;
<<<<<<< HEAD
    };

    _proto.cycle = function cycle(event) {
=======
    }

    cycle(event) {
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      if (!event) {
        this._isPaused = false;
      }

      if (this._interval) {
        clearInterval(this._interval);
        this._interval = null;
      }

<<<<<<< HEAD
      if (this._config.interval && !this._isPaused) {
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      if (this._config && this._config.interval && !this._isPaused) {
========
      if (this._config.interval && !this._isPaused) {
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
        this._updateInterval();

        this._interval = setInterval((document.visibilityState ? this.nextWhenVisible : this.next).bind(this), this._config.interval);
      }
<<<<<<< HEAD
    };

    _proto.to = function to(index) {
      var _this = this;

      this._activeElement = this._element.querySelector(SELECTOR_ACTIVE_ITEM);

      var activeIndex = this._getItemIndex(this._activeElement);
=======
    }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    to(index) {
      this._activeElement = SelectorEngine.findOne(SELECTOR_ACTIVE_ITEM, this._element);
========
      this._activeElement = this._element.querySelector(SELECTOR_ACTIVE_ITEM);
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

      const activeIndex = this._getItemIndex(this._activeElement);
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277

      if (index > this._items.length - 1 || index < 0) {
        return;
      }

      if (this._isSliding) {
<<<<<<< HEAD
        $__default['default'](this._element).one(EVENT_SLID, function () {
          return _this.to(index);
        });
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
        EventHandler.one(this._element, EVENT_SLID, () => this.to(index));
========
        $__default['default'](this._element).one(EVENT_SLID, function () {
          return _this.to(index);
        });
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
        return;
      }

      if (activeIndex === index) {
        this.pause();
        this.cycle();
        return;
      }

<<<<<<< HEAD
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      const order = index > activeIndex ? ORDER_NEXT : ORDER_PREV;

      this._slide(order, this._items[index]);
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      var direction = index > activeIndex ? DIRECTION_NEXT : DIRECTION_PREV;

      this._slide(direction, this._items[index]);
    };

    _proto.dispose = function dispose() {
      $__default['default'](this._element).off(EVENT_KEY$2);
      $__default['default'].removeData(this._element, DATA_KEY$2);
      this._items = null;
      this._config = null;
      this._element = null;
      this._interval = null;
      this._isPaused = null;
      this._isSliding = null;
      this._activeElement = null;
      this._indicatorsElement = null;
<<<<<<< HEAD
    } // Private
    ;

    _proto._getConfig = function _getConfig(config) {
      config = _extends({}, Default, config);
      Util.typeCheckConfig(NAME$2, config, DefaultType);
      return config;
    };

    _proto._handleSwipe = function _handleSwipe() {
      var absDeltax = Math.abs(this.touchDeltaX);
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
    } // Private

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js

    _getConfig(config) {
      config = { ...Default$a,
        ...Manipulator.getDataAttributes(this._element),
        ...(typeof config === 'object' ? config : {})
      };
      typeCheckConfig(NAME$b, config, DefaultType$a);
========
    _proto._getConfig = function _getConfig(config) {
      config = _extends({}, Default, config);
      Util.typeCheckConfig(NAME$2, config, DefaultType);
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
      return config;
    }

    _handleSwipe() {
      const absDeltax = Math.abs(this.touchDeltaX);
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277

      if (absDeltax <= SWIPE_THRESHOLD) {
        return;
      }

<<<<<<< HEAD
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      const direction = absDeltax / this.touchDeltaX;
      this.touchDeltaX = 0;
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      var direction = absDeltax / this.touchDeltaX;
      this.touchDeltaX = 0; // swipe left

      if (direction > 0) {
        this.prev();
      } // swipe right

<<<<<<< HEAD

      if (direction < 0) {
        this.next();
      }
    };

    _proto._addEventListeners = function _addEventListeners() {
      var _this2 = this;

      if (this._config.keyboard) {
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

      if (!direction) {
        return;
      }

      this._slide(direction > 0 ? DIRECTION_RIGHT : DIRECTION_LEFT);
    }

    _addEventListeners() {
      if (this._config.keyboard) {
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
        EventHandler.on(this._element, EVENT_KEYDOWN, event => this._keydown(event));
      }

      if (this._config.pause === 'hover') {
        EventHandler.on(this._element, EVENT_MOUSEENTER, event => this.pause(event));
        EventHandler.on(this._element, EVENT_MOUSELEAVE, event => this.cycle(event));
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
        $__default['default'](this._element).on(EVENT_KEYDOWN, function (event) {
          return _this2._keydown(event);
        });
      }

      if (this._config.pause === 'hover') {
        $__default['default'](this._element).on(EVENT_MOUSEENTER, function (event) {
          return _this2.pause(event);
        }).on(EVENT_MOUSELEAVE, function (event) {
          return _this2.cycle(event);
        });
<<<<<<< HEAD
      }

      if (this._config.touch) {
        this._addTouchEventListeners();
      }
    };

    _proto._addTouchEventListeners = function _addTouchEventListeners() {
      var _this3 = this;

      if (!this._touchSupported) {
        return;
      }

      var start = function start(event) {
        if (_this3._pointerEvent && PointerType[event.originalEvent.pointerType.toUpperCase()]) {
          _this3.touchStartX = event.originalEvent.clientX;
        } else if (!_this3._pointerEvent) {
          _this3.touchStartX = event.originalEvent.touches[0].clientX;
        }
      };

      var move = function move(event) {
        // ensure swiping with one touch and not pinching
        if (event.originalEvent.touches && event.originalEvent.touches.length > 1) {
          _this3.touchDeltaX = 0;
        } else {
          _this3.touchDeltaX = event.originalEvent.touches[0].clientX - _this3.touchStartX;
        }
      };

      var end = function end(event) {
        if (_this3._pointerEvent && PointerType[event.originalEvent.pointerType.toUpperCase()]) {
          _this3.touchDeltaX = event.originalEvent.clientX - _this3.touchStartX;
        }

        _this3._handleSwipe();

        if (_this3._config.pause === 'hover') {
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
      }

      if (this._config.touch && this._touchSupported) {
        this._addTouchEventListeners();
      }
    }

    _addTouchEventListeners() {
      const start = event => {
        if (this._pointerEvent && (event.pointerType === POINTER_TYPE_PEN || event.pointerType === POINTER_TYPE_TOUCH)) {
          this.touchStartX = event.clientX;
        } else if (!this._pointerEvent) {
          this.touchStartX = event.touches[0].clientX;
        }
      };

      const move = event => {
        // ensure swiping with one touch and not pinching
        this.touchDeltaX = event.touches && event.touches.length > 1 ? 0 : event.touches[0].clientX - this.touchStartX;
      };

      const end = event => {
        if (this._pointerEvent && (event.pointerType === POINTER_TYPE_PEN || event.pointerType === POINTER_TYPE_TOUCH)) {
          this.touchDeltaX = event.clientX - this.touchStartX;
        }

        this._handleSwipe();

        if (this._config.pause === 'hover') {
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
          // If it's a touch-enabled device, mouseenter/leave are fired as
          // part of the mouse compatibility events on first tap - the carousel
          // would stop cycling until user tapped out of it;
          // here, we listen for touchend, explicitly pause the carousel
          // (as if it's the second time we tap on it, mouseenter compat event
          // is NOT fired) and after a timeout (to allow for mouse compatibility
          // events to fire) we explicitly restart cycling
<<<<<<< HEAD
          _this3.pause();

          if (_this3.touchTimeout) {
            clearTimeout(_this3.touchTimeout);
          }

          _this3.touchTimeout = setTimeout(function (event) {
            return _this3.cycle(event);
          }, TOUCHEVENT_COMPAT_WAIT + _this3._config.interval);
        }
      };

=======
          this.pause();

          if (this.touchTimeout) {
            clearTimeout(this.touchTimeout);
          }

          this.touchTimeout = setTimeout(event => this.cycle(event), TOUCHEVENT_COMPAT_WAIT + this._config.interval);
        }
      };

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      SelectorEngine.find(SELECTOR_ITEM_IMG, this._element).forEach(itemImg => {
        EventHandler.on(itemImg, EVENT_DRAG_START, e => e.preventDefault());
      });

      if (this._pointerEvent) {
        EventHandler.on(this._element, EVENT_POINTERDOWN, event => start(event));
        EventHandler.on(this._element, EVENT_POINTERUP, event => end(event));

        this._element.classList.add(CLASS_NAME_POINTER_EVENT);
      } else {
        EventHandler.on(this._element, EVENT_TOUCHSTART, event => start(event));
        EventHandler.on(this._element, EVENT_TOUCHMOVE, event => move(event));
        EventHandler.on(this._element, EVENT_TOUCHEND, event => end(event));
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      $__default['default'](this._element.querySelectorAll(SELECTOR_ITEM_IMG)).on(EVENT_DRAG_START, function (e) {
        return e.preventDefault();
      });

      if (this._pointerEvent) {
        $__default['default'](this._element).on(EVENT_POINTERDOWN, function (event) {
          return start(event);
        });
        $__default['default'](this._element).on(EVENT_POINTERUP, function (event) {
          return end(event);
        });

        this._element.classList.add(CLASS_NAME_POINTER_EVENT);
      } else {
        $__default['default'](this._element).on(EVENT_TOUCHSTART, function (event) {
          return start(event);
        });
        $__default['default'](this._element).on(EVENT_TOUCHMOVE, function (event) {
          return move(event);
        });
        $__default['default'](this._element).on(EVENT_TOUCHEND, function (event) {
          return end(event);
        });
<<<<<<< HEAD
      }
    };

    _proto._keydown = function _keydown(event) {
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
      }
    }

    _keydown(event) {
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      if (/input|textarea/i.test(event.target.tagName)) {
        return;
      }

<<<<<<< HEAD
      switch (event.which) {
        case ARROW_LEFT_KEYCODE:
          event.preventDefault();
          this.prev();
          break;

=======
      const direction = KEY_TO_DIRECTION[event.key];

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      if (direction) {
        event.preventDefault();

        this._slide(direction);
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
        case ARROW_RIGHT_KEYCODE:
          event.preventDefault();
          this.next();
          break;
<<<<<<< HEAD
      }
    };

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
      }
    }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    _getItemIndex(element) {
      this._items = element && element.parentNode ? SelectorEngine.find(SELECTOR_ITEM, element.parentNode) : [];
      return this._items.indexOf(element);
    }

    _getItemByOrder(order, activeElement) {
      const isNext = order === ORDER_NEXT;
      return getNextActiveElement(this._items, activeElement, isNext, this._config.wrap);
    }
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    _proto._getItemIndex = function _getItemIndex(element) {
      this._items = element && element.parentNode ? [].slice.call(element.parentNode.querySelectorAll(SELECTOR_ITEM)) : [];
      return this._items.indexOf(element);
    };

    _proto._getItemByDirection = function _getItemByDirection(direction, activeElement) {
      var isNextDirection = direction === DIRECTION_NEXT;
      var isPrevDirection = direction === DIRECTION_PREV;

      var activeIndex = this._getItemIndex(activeElement);

      var lastItemIndex = this._items.length - 1;
      var isGoingToWrap = isPrevDirection && activeIndex === 0 || isNextDirection && activeIndex === lastItemIndex;

      if (isGoingToWrap && !this._config.wrap) {
        return activeElement;
      }

      var delta = direction === DIRECTION_PREV ? -1 : 1;
      var itemIndex = (activeIndex + delta) % this._items.length;
      return itemIndex === -1 ? this._items[this._items.length - 1] : this._items[itemIndex];
    };
<<<<<<< HEAD

    _proto._triggerSlideEvent = function _triggerSlideEvent(relatedTarget, eventDirectionName) {
      var targetIndex = this._getItemIndex(relatedTarget);

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

    _triggerSlideEvent(relatedTarget, eventDirectionName) {
      const targetIndex = this._getItemIndex(relatedTarget);

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      const fromIndex = this._getItemIndex(SelectorEngine.findOne(SELECTOR_ACTIVE_ITEM, this._element));

      return EventHandler.trigger(this._element, EVENT_SLIDE, {
        relatedTarget,
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      var fromIndex = this._getItemIndex(this._element.querySelector(SELECTOR_ACTIVE_ITEM));

      var slideEvent = $__default['default'].Event(EVENT_SLIDE, {
        relatedTarget: relatedTarget,
<<<<<<< HEAD
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
        direction: eventDirectionName,
        from: fromIndex,
        to: targetIndex
      });
<<<<<<< HEAD
      $__default['default'](this._element).trigger(slideEvent);
      return slideEvent;
    };

    _proto._setActiveIndicatorElement = function _setActiveIndicatorElement(element) {
      if (this._indicatorsElement) {
        var indicators = [].slice.call(this._indicatorsElement.querySelectorAll(SELECTOR_ACTIVE$1));
        $__default['default'](indicators).removeClass(CLASS_NAME_ACTIVE$1);

        var nextIndicator = this._indicatorsElement.children[this._getItemIndex(element)];

        if (nextIndicator) {
          $__default['default'](nextIndicator).addClass(CLASS_NAME_ACTIVE$1);
        }
      }
    };

=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    }
========
      $__default['default'](this._element).trigger(slideEvent);
      return slideEvent;
    };
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

    _setActiveIndicatorElement(element) {
      if (this._indicatorsElement) {
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
        const activeIndicator = SelectorEngine.findOne(SELECTOR_ACTIVE$1, this._indicatorsElement);
        activeIndicator.classList.remove(CLASS_NAME_ACTIVE$2);
        activeIndicator.removeAttribute('aria-current');
        const indicators = SelectorEngine.find(SELECTOR_INDICATOR, this._indicatorsElement);

        for (let i = 0; i < indicators.length; i++) {
          if (Number.parseInt(indicators[i].getAttribute('data-bs-slide-to'), 10) === this._getItemIndex(element)) {
            indicators[i].classList.add(CLASS_NAME_ACTIVE$2);
            indicators[i].setAttribute('aria-current', 'true');
            break;
          }
        }
      }
    }
========
        var indicators = [].slice.call(this._indicatorsElement.querySelectorAll(SELECTOR_ACTIVE$1));
        $__default['default'](indicators).removeClass(CLASS_NAME_ACTIVE$1);
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

    _updateInterval() {
      const element = this._activeElement || SelectorEngine.findOne(SELECTOR_ACTIVE_ITEM, this._element);

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      if (!element) {
        return;
========
        if (nextIndicator) {
          $__default['default'](nextIndicator).addClass(CLASS_NAME_ACTIVE$1);
        }
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
      }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      const elementInterval = Number.parseInt(element.getAttribute('data-bs-interval'), 10);

      if (elementInterval) {
        this._config.defaultInterval = this._config.defaultInterval || this._config.interval;
        this._config.interval = elementInterval;
      } else {
        this._config.interval = this._config.defaultInterval || this._config.interval;
      }
    }
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    _proto._updateInterval = function _updateInterval() {
      var element = this._activeElement || this._element.querySelector(SELECTOR_ACTIVE_ITEM);

      if (!element) {
        return;
      }

      var elementInterval = parseInt(element.getAttribute('data-interval'), 10);

      if (elementInterval) {
        this._config.defaultInterval = this._config.defaultInterval || this._config.interval;
        this._config.interval = elementInterval;
      } else {
        this._config.interval = this._config.defaultInterval || this._config.interval;
      }
    };

    _proto._slide = function _slide(direction, element) {
      var _this4 = this;

      var activeElement = this._element.querySelector(SELECTOR_ACTIVE_ITEM);
<<<<<<< HEAD

      var activeElementIndex = this._getItemIndex(activeElement);

      var nextElement = element || activeElement && this._getItemByDirection(direction, activeElement);

      var nextElementIndex = this._getItemIndex(nextElement);

      var isCycling = Boolean(this._interval);
      var directionalClassName;
      var orderClassName;
      var eventDirectionName;

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

    _slide(directionOrOrder, element) {
      const order = this._directionToOrder(directionOrOrder);

      const activeElement = SelectorEngine.findOne(SELECTOR_ACTIVE_ITEM, this._element);

      const activeElementIndex = this._getItemIndex(activeElement);

      const nextElement = element || this._getItemByOrder(order, activeElement);

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      const nextElementIndex = this._getItemIndex(nextElement);

      const isCycling = Boolean(this._interval);
      const isNext = order === ORDER_NEXT;
      const directionalClassName = isNext ? CLASS_NAME_START : CLASS_NAME_END;
      const orderClassName = isNext ? CLASS_NAME_NEXT : CLASS_NAME_PREV;

      const eventDirectionName = this._orderToDirection(order);

      if (nextElement && nextElement.classList.contains(CLASS_NAME_ACTIVE$2)) {
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      if (direction === DIRECTION_NEXT) {
        directionalClassName = CLASS_NAME_LEFT;
        orderClassName = CLASS_NAME_NEXT;
        eventDirectionName = DIRECTION_LEFT;
      } else {
        directionalClassName = CLASS_NAME_RIGHT;
        orderClassName = CLASS_NAME_PREV;
        eventDirectionName = DIRECTION_RIGHT;
      }

      if (nextElement && $__default['default'](nextElement).hasClass(CLASS_NAME_ACTIVE$1)) {
<<<<<<< HEAD
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
        this._isSliding = false;
        return;
      }

<<<<<<< HEAD
      var slideEvent = this._triggerSlideEvent(nextElement, eventDirectionName);

      if (slideEvent.isDefaultPrevented()) {
        return;
      }

      if (!activeElement || !nextElement) {
        // Some weirdness is happening, so we bail
        return;
      }

      this._isSliding = true;

      if (isCycling) {
        this.pause();
      }

      this._setActiveIndicatorElement(nextElement);

      this._activeElement = nextElement;
=======
      if (this._isSliding) {
        return;
      }

      const slideEvent = this._triggerSlideEvent(nextElement, eventDirectionName);

      if (slideEvent.defaultPrevented) {
        return;
      }

      if (!activeElement || !nextElement) {
        // Some weirdness is happening, so we bail
        return;
      }

      this._isSliding = true;

      if (isCycling) {
        this.pause();
      }

      this._setActiveIndicatorElement(nextElement);

      this._activeElement = nextElement;
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js

      const triggerSlidEvent = () => {
        EventHandler.trigger(this._element, EVENT_SLID, {
          relatedTarget: nextElement,
          direction: eventDirectionName,
          from: activeElementIndex,
          to: nextElementIndex
        });
      };

      if (this._element.classList.contains(CLASS_NAME_SLIDE)) {
        nextElement.classList.add(orderClassName);
        reflow(nextElement);
        activeElement.classList.add(directionalClassName);
        nextElement.classList.add(directionalClassName);

        const completeCallBack = () => {
          nextElement.classList.remove(directionalClassName, orderClassName);
          nextElement.classList.add(CLASS_NAME_ACTIVE$2);
          activeElement.classList.remove(CLASS_NAME_ACTIVE$2, orderClassName, directionalClassName);
          this._isSliding = false;
          setTimeout(triggerSlidEvent, 0);
        };

        this._queueCallback(completeCallBack, activeElement, true);
      } else {
        activeElement.classList.remove(CLASS_NAME_ACTIVE$2);
        nextElement.classList.add(CLASS_NAME_ACTIVE$2);
        this._isSliding = false;
        triggerSlidEvent();
      }

      if (isCycling) {
        this.cycle();
      }
    }

    _directionToOrder(direction) {
      if (![DIRECTION_RIGHT, DIRECTION_LEFT].includes(direction)) {
        return direction;
      }

      if (isRTL()) {
        return direction === DIRECTION_LEFT ? ORDER_PREV : ORDER_NEXT;
      }

      return direction === DIRECTION_LEFT ? ORDER_NEXT : ORDER_PREV;
    }

    _orderToDirection(order) {
      if (![ORDER_NEXT, ORDER_PREV].includes(order)) {
        return order;
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      var slidEvent = $__default['default'].Event(EVENT_SLID, {
        relatedTarget: nextElement,
        direction: eventDirectionName,
        from: activeElementIndex,
        to: nextElementIndex
      });

      if ($__default['default'](this._element).hasClass(CLASS_NAME_SLIDE)) {
        $__default['default'](nextElement).addClass(orderClassName);
        Util.reflow(nextElement);
        $__default['default'](activeElement).addClass(directionalClassName);
        $__default['default'](nextElement).addClass(directionalClassName);
        var transitionDuration = Util.getTransitionDurationFromElement(activeElement);
        $__default['default'](activeElement).one(Util.TRANSITION_END, function () {
          $__default['default'](nextElement).removeClass(directionalClassName + " " + orderClassName).addClass(CLASS_NAME_ACTIVE$1);
          $__default['default'](activeElement).removeClass(CLASS_NAME_ACTIVE$1 + " " + orderClassName + " " + directionalClassName);
          _this4._isSliding = false;
          setTimeout(function () {
            return $__default['default'](_this4._element).trigger(slidEvent);
          }, 0);
        }).emulateTransitionEnd(transitionDuration);
      } else {
        $__default['default'](activeElement).removeClass(CLASS_NAME_ACTIVE$1);
        $__default['default'](nextElement).addClass(CLASS_NAME_ACTIVE$1);
        this._isSliding = false;
        $__default['default'](this._element).trigger(slidEvent);
<<<<<<< HEAD
      }

      if (isCycling) {
        this.cycle();
      }
    } // Static
    ;

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
      }

      if (isRTL()) {
        return order === ORDER_PREV ? DIRECTION_LEFT : DIRECTION_RIGHT;
      }

      return order === ORDER_PREV ? DIRECTION_RIGHT : DIRECTION_LEFT;
    } // Static

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js

    static carouselInterface(element, config) {
      const data = Carousel.getOrCreateInstance(element, config);
      let {
        _config
      } = data;

      if (typeof config === 'object') {
        _config = { ..._config,
          ...config
        };
      }
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    Carousel._jQueryInterface = function _jQueryInterface(config) {
      return this.each(function () {
        var data = $__default['default'](this).data(DATA_KEY$2);

        var _config = _extends({}, Default, $__default['default'](this).data());

        if (typeof config === 'object') {
          _config = _extends({}, _config, config);
        }
<<<<<<< HEAD

        var action = typeof config === 'string' ? config : _config.slide;

        if (!data) {
          data = new Carousel(this, _config);
          $__default['default'](this).data(DATA_KEY$2, data);
        }

        if (typeof config === 'number') {
          data.to(config);
        } else if (typeof action === 'string') {
          if (typeof data[action] === 'undefined') {
            throw new TypeError("No method named \"" + action + "\"");
          }

          data[action]();
        } else if (_config.interval && _config.ride) {
          data.pause();
          data.cycle();
        }
      });
    };

    Carousel._dataApiClickHandler = function _dataApiClickHandler(event) {
      var selector = Util.getSelectorFromElement(this);

      if (!selector) {
        return;
      }

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

      const action = typeof config === 'string' ? config : _config.slide;

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      if (typeof config === 'number') {
        data.to(config);
      } else if (typeof action === 'string') {
        if (typeof data[action] === 'undefined') {
          throw new TypeError(`No method named "${action}"`);
========
        if (!data) {
          data = new Carousel(this, _config);
          $__default['default'](this).data(DATA_KEY$2, data);
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
        }

        data[action]();
      } else if (_config.interval && _config.ride) {
        data.pause();
        data.cycle();
      }
    }

    static jQueryInterface(config) {
      return this.each(function () {
        Carousel.carouselInterface(this, config);
      });
    }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    static dataApiClickHandler(event) {
      const target = getElementFromSelector(this);

      if (!target || !target.classList.contains(CLASS_NAME_CAROUSEL)) {
        return;
      }

      const config = { ...Manipulator.getDataAttributes(target),
        ...Manipulator.getDataAttributes(this)
      };
      const slideIndex = this.getAttribute('data-bs-slide-to');
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      var target = $__default['default'](selector)[0];

      if (!target || !$__default['default'](target).hasClass(CLASS_NAME_CAROUSEL)) {
        return;
      }

      var config = _extends({}, $__default['default'](target).data(), $__default['default'](this).data());

      var slideIndex = this.getAttribute('data-slide-to');
<<<<<<< HEAD
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277

      if (slideIndex) {
        config.interval = false;
      }

<<<<<<< HEAD
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      Carousel.carouselInterface(target, config);

      if (slideIndex) {
        Carousel.getInstance(target).to(slideIndex);
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      Carousel._jQueryInterface.call($__default['default'](target), config);

      if (slideIndex) {
        $__default['default'](target).data(DATA_KEY$2).to(slideIndex);
<<<<<<< HEAD
      }

      event.preventDefault();
    };

    _createClass(Carousel, null, [{
      key: "VERSION",
      get: function get() {
        return VERSION$2;
      }
    }, {
      key: "Default",
      get: function get() {
        return Default;
      }
    }]);

    return Carousel;
  }();
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
      }

      event.preventDefault();
    }

  }
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  /**
   * ------------------------------------------------------------------------
   * Data Api implementation
   * ------------------------------------------------------------------------
   */


<<<<<<< HEAD
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  EventHandler.on(document, EVENT_CLICK_DATA_API$5, SELECTOR_DATA_SLIDE, Carousel.dataApiClickHandler);
  EventHandler.on(window, EVENT_LOAD_DATA_API$2, () => {
    const carousels = SelectorEngine.find(SELECTOR_DATA_RIDE);
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  $__default['default'](document).on(EVENT_CLICK_DATA_API$2, SELECTOR_DATA_SLIDE, Carousel._dataApiClickHandler);
  $__default['default'](window).on(EVENT_LOAD_DATA_API$1, function () {
    var carousels = [].slice.call(document.querySelectorAll(SELECTOR_DATA_RIDE));

    for (var i = 0, len = carousels.length; i < len; i++) {
      var $carousel = $__default['default'](carousels[i]);
<<<<<<< HEAD

      Carousel._jQueryInterface.call($carousel, $carousel.data());
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

    for (let i = 0, len = carousels.length; i < len; i++) {
      Carousel.carouselInterface(carousels[i], Carousel.getInstance(carousels[i]));
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    }
  });
  /**
   * ------------------------------------------------------------------------
   * jQuery
   * ------------------------------------------------------------------------
<<<<<<< HEAD
   */

=======
   * add .Carousel to jQuery only if jQuery is present
   */

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  defineJQueryPlugin(Carousel);
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  $__default['default'].fn[NAME$2] = Carousel._jQueryInterface;
  $__default['default'].fn[NAME$2].Constructor = Carousel;

  $__default['default'].fn[NAME$2].noConflict = function () {
    $__default['default'].fn[NAME$2] = JQUERY_NO_CONFLICT$2;
    return Carousel._jQueryInterface;
  };
<<<<<<< HEAD

  /**
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

  /**
   * --------------------------------------------------------------------------
   * Bootstrap (v5.1.0): collapse.js
   * Licensed under MIT (https://github.com/twbs/bootstrap/blob/main/LICENSE)
   * --------------------------------------------------------------------------
   */
  /**
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
   * ------------------------------------------------------------------------
   * Constants
   * ------------------------------------------------------------------------
   */

<<<<<<< HEAD
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  const NAME$a = 'collapse';
  const DATA_KEY$9 = 'bs.collapse';
  const EVENT_KEY$9 = `.${DATA_KEY$9}`;
  const DATA_API_KEY$5 = '.data-api';
  const Default$9 = {
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  var NAME$3 = 'collapse';
  var VERSION$3 = '4.6.0';
  var DATA_KEY$3 = 'bs.collapse';
  var EVENT_KEY$3 = "." + DATA_KEY$3;
  var DATA_API_KEY$3 = '.data-api';
  var JQUERY_NO_CONFLICT$3 = $__default['default'].fn[NAME$3];
  var Default$1 = {
<<<<<<< HEAD
    toggle: true,
    parent: ''
  };
  var DefaultType$1 = {
    toggle: 'boolean',
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
    toggle: true,
    parent: null
  };
  const DefaultType$9 = {
    toggle: 'boolean',
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    parent: '(null|element)'
  };
  const EVENT_SHOW$5 = `show${EVENT_KEY$9}`;
  const EVENT_SHOWN$5 = `shown${EVENT_KEY$9}`;
  const EVENT_HIDE$5 = `hide${EVENT_KEY$9}`;
  const EVENT_HIDDEN$5 = `hidden${EVENT_KEY$9}`;
  const EVENT_CLICK_DATA_API$4 = `click${EVENT_KEY$9}${DATA_API_KEY$5}`;
  const CLASS_NAME_SHOW$7 = 'show';
  const CLASS_NAME_COLLAPSE = 'collapse';
  const CLASS_NAME_COLLAPSING = 'collapsing';
  const CLASS_NAME_COLLAPSED = 'collapsed';
  const CLASS_NAME_HORIZONTAL = 'collapse-horizontal';
  const WIDTH = 'width';
  const HEIGHT = 'height';
  const SELECTOR_ACTIVES = '.show, .collapsing';
  const SELECTOR_DATA_TOGGLE$4 = '[data-bs-toggle="collapse"]';
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    parent: '(string|element)'
  };
  var EVENT_SHOW = "show" + EVENT_KEY$3;
  var EVENT_SHOWN = "shown" + EVENT_KEY$3;
  var EVENT_HIDE = "hide" + EVENT_KEY$3;
  var EVENT_HIDDEN = "hidden" + EVENT_KEY$3;
  var EVENT_CLICK_DATA_API$3 = "click" + EVENT_KEY$3 + DATA_API_KEY$3;
  var CLASS_NAME_SHOW$1 = 'show';
  var CLASS_NAME_COLLAPSE = 'collapse';
  var CLASS_NAME_COLLAPSING = 'collapsing';
  var CLASS_NAME_COLLAPSED = 'collapsed';
  var DIMENSION_WIDTH = 'width';
  var DIMENSION_HEIGHT = 'height';
  var SELECTOR_ACTIVES = '.show, .collapsing';
  var SELECTOR_DATA_TOGGLE$1 = '[data-toggle="collapse"]';
<<<<<<< HEAD
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  /**
   * ------------------------------------------------------------------------
   * Class Definition
   * ------------------------------------------------------------------------
   */

<<<<<<< HEAD
  var Collapse = /*#__PURE__*/function () {
    function Collapse(element, config) {
      this._isTransitioning = false;
      this._element = element;
      this._config = this._getConfig(config);
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  class Collapse extends BaseComponent {
    constructor(element, config) {
      super(element);
========
  var Collapse = /*#__PURE__*/function () {
    function Collapse(element, config) {
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
      this._isTransitioning = false;
      this._config = this._getConfig(config);
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      this._triggerArray = [];
      const toggleList = SelectorEngine.find(SELECTOR_DATA_TOGGLE$4);

      for (let i = 0, len = toggleList.length; i < len; i++) {
        const elem = toggleList[i];
        const selector = getSelectorFromElement(elem);
        const filterElement = SelectorEngine.find(selector).filter(foundElem => foundElem === this._element);
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      this._triggerArray = [].slice.call(document.querySelectorAll("[data-toggle=\"collapse\"][href=\"#" + element.id + "\"]," + ("[data-toggle=\"collapse\"][data-target=\"#" + element.id + "\"]")));
      var toggleList = [].slice.call(document.querySelectorAll(SELECTOR_DATA_TOGGLE$1));

      for (var i = 0, len = toggleList.length; i < len; i++) {
        var elem = toggleList[i];
        var selector = Util.getSelectorFromElement(elem);
        var filterElement = [].slice.call(document.querySelectorAll(selector)).filter(function (foundElem) {
          return foundElem === element;
        });
<<<<<<< HEAD

        if (selector !== null && filterElement.length > 0) {
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

        if (selector !== null && filterElement.length) {
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
          this._selector = selector;

          this._triggerArray.push(elem);
        }
      }

<<<<<<< HEAD
      this._parent = this._config.parent ? this._getParent() : null;

      if (!this._config.parent) {
        this._addAriaAndCollapsedClass(this._element, this._triggerArray);
=======
      this._initializeChildren();

      if (!this._config.parent) {
        this._addAriaAndCollapsedClass(this._triggerArray, this._isShown());
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      }

      if (this._config.toggle) {
        this.toggle();
      }
    } // Getters


<<<<<<< HEAD
    var _proto = Collapse.prototype;

    // Public
    _proto.toggle = function toggle() {
      if ($__default['default'](this._element).hasClass(CLASS_NAME_SHOW$1)) {
=======
    static get Default() {
      return Default$9;
    }

    static get NAME() {
      return NAME$a;
    } // Public

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js

    toggle() {
      if (this._isShown()) {
========
    // Public
    _proto.toggle = function toggle() {
      if ($__default['default'](this._element).hasClass(CLASS_NAME_SHOW$1)) {
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
        this.hide();
      } else {
        this.show();
      }
<<<<<<< HEAD
    };

    _proto.show = function show() {
      var _this = this;

=======
    }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    show() {
      if (this._isTransitioning || this._isShown()) {
        return;
      }

      let actives = [];
      let activesData;
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      if (this._isTransitioning || $__default['default'](this._element).hasClass(CLASS_NAME_SHOW$1)) {
        return;
      }

      var actives;
      var activesData;

      if (this._parent) {
        actives = [].slice.call(this._parent.querySelectorAll(SELECTOR_ACTIVES)).filter(function (elem) {
          if (typeof _this._config.parent === 'string') {
            return elem.getAttribute('data-parent') === _this._config.parent;
          }

          return elem.classList.contains(CLASS_NAME_COLLAPSE);
        });
<<<<<<< HEAD

        if (actives.length === 0) {
          actives = null;
        }
      }

      if (actives) {
        activesData = $__default['default'](actives).not(this._selector).data(DATA_KEY$3);
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

      if (this._config.parent) {
        const children = SelectorEngine.find(`.${CLASS_NAME_COLLAPSE} .${CLASS_NAME_COLLAPSE}`, this._config.parent);
        actives = SelectorEngine.find(SELECTOR_ACTIVES, this._config.parent).filter(elem => !children.includes(elem)); // remove children if greater depth
      }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      const container = SelectorEngine.findOne(this._selector);

      if (actives.length) {
        const tempActiveData = actives.find(elem => container !== elem);
        activesData = tempActiveData ? Collapse.getInstance(tempActiveData) : null;
========
      if (actives) {
        activesData = $__default['default'](actives).not(this._selector).data(DATA_KEY$3);
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277

        if (activesData && activesData._isTransitioning) {
          return;
        }
      }

<<<<<<< HEAD
      var startEvent = $__default['default'].Event(EVENT_SHOW);
      $__default['default'](this._element).trigger(startEvent);

      if (startEvent.isDefaultPrevented()) {
        return;
      }

=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      const startEvent = EventHandler.trigger(this._element, EVENT_SHOW$5);
========
      var startEvent = $__default['default'].Event(EVENT_SHOW);
      $__default['default'](this._element).trigger(startEvent);
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

      if (startEvent.defaultPrevented) {
        return;
      }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      actives.forEach(elemActive => {
        if (container !== elemActive) {
          Collapse.getOrCreateInstance(elemActive, {
            toggle: false
          }).hide();
        }

        if (!activesData) {
          Data.set(elemActive, DATA_KEY$9, null);
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      if (actives) {
        Collapse._jQueryInterface.call($__default['default'](actives).not(this._selector), 'hide');

        if (!activesData) {
          $__default['default'](actives).data(DATA_KEY$3, null);
<<<<<<< HEAD
        }
      }

      var dimension = this._getDimension();

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
        }
      });

      const dimension = this._getDimension();

      this._element.classList.remove(CLASS_NAME_COLLAPSE);

      this._element.classList.add(CLASS_NAME_COLLAPSING);

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      this._element.style[dimension] = 0;

      this._addAriaAndCollapsedClass(this._triggerArray, true);
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      $__default['default'](this._element).removeClass(CLASS_NAME_COLLAPSE).addClass(CLASS_NAME_COLLAPSING);
      this._element.style[dimension] = 0;

      if (this._triggerArray.length) {
        $__default['default'](this._triggerArray).removeClass(CLASS_NAME_COLLAPSED).attr('aria-expanded', true);
      }
<<<<<<< HEAD

      this.setTransitioning(true);

      var complete = function complete() {
        $__default['default'](_this._element).removeClass(CLASS_NAME_COLLAPSING).addClass(CLASS_NAME_COLLAPSE + " " + CLASS_NAME_SHOW$1);
        _this._element.style[dimension] = '';

        _this.setTransitioning(false);

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

      this._isTransitioning = true;

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      const complete = () => {
        this._isTransitioning = false;
========
      var complete = function complete() {
        $__default['default'](_this._element).removeClass(CLASS_NAME_COLLAPSING).addClass(CLASS_NAME_COLLAPSE + " " + CLASS_NAME_SHOW$1);
        _this._element.style[dimension] = '';
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

        this._element.classList.remove(CLASS_NAME_COLLAPSING);

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
        this._element.classList.add(CLASS_NAME_COLLAPSE, CLASS_NAME_SHOW$7);

        this._element.style[dimension] = '';
        EventHandler.trigger(this._element, EVENT_SHOWN$5);
      };

      const capitalizedDimension = dimension[0].toUpperCase() + dimension.slice(1);
      const scrollSize = `scroll${capitalizedDimension}`;
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
        $__default['default'](_this._element).trigger(EVENT_SHOWN);
      };

      var capitalizedDimension = dimension[0].toUpperCase() + dimension.slice(1);
      var scrollSize = "scroll" + capitalizedDimension;
      var transitionDuration = Util.getTransitionDurationFromElement(this._element);
      $__default['default'](this._element).one(Util.TRANSITION_END, complete).emulateTransitionEnd(transitionDuration);
      this._element.style[dimension] = this._element[scrollSize] + "px";
    };
<<<<<<< HEAD

    _proto.hide = function hide() {
      var _this2 = this;

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

      this._queueCallback(complete, this._element, true);

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      this._element.style[dimension] = `${this._element[scrollSize]}px`;
    }

    hide() {
      if (this._isTransitioning || !this._isShown()) {
        return;
      }

      const startEvent = EventHandler.trigger(this._element, EVENT_HIDE$5);
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      if (this._isTransitioning || !$__default['default'](this._element).hasClass(CLASS_NAME_SHOW$1)) {
        return;
      }

      var startEvent = $__default['default'].Event(EVENT_HIDE);
      $__default['default'](this._element).trigger(startEvent);
<<<<<<< HEAD

      if (startEvent.isDefaultPrevented()) {
        return;
      }

      var dimension = this._getDimension();

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

      if (startEvent.defaultPrevented) {
        return;
      }

      const dimension = this._getDimension();

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      this._element.style[dimension] = `${this._element.getBoundingClientRect()[dimension]}px`;
      reflow(this._element);
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      this._element.style[dimension] = this._element.getBoundingClientRect()[dimension] + "px";
      Util.reflow(this._element);
      $__default['default'](this._element).addClass(CLASS_NAME_COLLAPSING).removeClass(CLASS_NAME_COLLAPSE + " " + CLASS_NAME_SHOW$1);
      var triggerArrayLength = this._triggerArray.length;
<<<<<<< HEAD

      if (triggerArrayLength > 0) {
        for (var i = 0; i < triggerArrayLength; i++) {
          var trigger = this._triggerArray[i];
          var selector = Util.getSelectorFromElement(trigger);

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

      this._element.classList.add(CLASS_NAME_COLLAPSING);

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      this._element.classList.remove(CLASS_NAME_COLLAPSE, CLASS_NAME_SHOW$7);

      const triggerArrayLength = this._triggerArray.length;

      for (let i = 0; i < triggerArrayLength; i++) {
        const trigger = this._triggerArray[i];
        const elem = getElementFromSelector(trigger);

        if (elem && !this._isShown(elem)) {
          this._addAriaAndCollapsedClass([trigger], false);
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
          if (selector !== null) {
            var $elem = $__default['default']([].slice.call(document.querySelectorAll(selector)));

            if (!$elem.hasClass(CLASS_NAME_SHOW$1)) {
              $__default['default'](trigger).addClass(CLASS_NAME_COLLAPSED).attr('aria-expanded', false);
            }
          }
<<<<<<< HEAD
        }
      }

      this.setTransitioning(true);

      var complete = function complete() {
        _this2.setTransitioning(false);

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
        }
      }

      this._isTransitioning = true;

      const complete = () => {
        this._isTransitioning = false;

        this._element.classList.remove(CLASS_NAME_COLLAPSING);

        this._element.classList.add(CLASS_NAME_COLLAPSE);

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
        EventHandler.trigger(this._element, EVENT_HIDDEN$5);
      };

      this._element.style[dimension] = '';
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
        $__default['default'](_this2._element).removeClass(CLASS_NAME_COLLAPSING).addClass(CLASS_NAME_COLLAPSE).trigger(EVENT_HIDDEN);
      };

      this._element.style[dimension] = '';
      var transitionDuration = Util.getTransitionDurationFromElement(this._element);
      $__default['default'](this._element).one(Util.TRANSITION_END, complete).emulateTransitionEnd(transitionDuration);
    };
<<<<<<< HEAD

    _proto.setTransitioning = function setTransitioning(isTransitioning) {
      this._isTransitioning = isTransitioning;
    };

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

      this._queueCallback(complete, this._element, true);
    }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    _isShown(element = this._element) {
      return element.classList.contains(CLASS_NAME_SHOW$7);
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    _proto.dispose = function dispose() {
      $__default['default'].removeData(this._element, DATA_KEY$3);
      this._config = null;
      this._parent = null;
      this._element = null;
      this._triggerArray = null;
      this._isTransitioning = null;
<<<<<<< HEAD
    } // Private
    ;

    _proto._getConfig = function _getConfig(config) {
      config = _extends({}, Default$1, config);
      config.toggle = Boolean(config.toggle); // Coerce string values

      Util.typeCheckConfig(NAME$3, config, DefaultType$1);
      return config;
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
    } // Private

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js

    _getConfig(config) {
      config = { ...Default$9,
        ...Manipulator.getDataAttributes(this._element),
        ...config
      };
========
    _proto._getConfig = function _getConfig(config) {
      config = _extends({}, Default$1, config);
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
      config.toggle = Boolean(config.toggle); // Coerce string values

      config.parent = getElement(config.parent);
      typeCheckConfig(NAME$a, config, DefaultType$9);
      return config;
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    }
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    };

    _proto._getDimension = function _getDimension() {
      var hasWidth = $__default['default'](this._element).hasClass(DIMENSION_WIDTH);
      return hasWidth ? DIMENSION_WIDTH : DIMENSION_HEIGHT;
    };
<<<<<<< HEAD

    _proto._getParent = function _getParent() {
      var _this3 = this;

      var parent;

      if (Util.isElement(this._config.parent)) {
        parent = this._config.parent; // It's a jQuery object

        if (typeof this._config.parent.jquery !== 'undefined') {
          parent = this._config.parent[0];
        }
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

    _getDimension() {
      return this._element.classList.contains(CLASS_NAME_HORIZONTAL) ? WIDTH : HEIGHT;
    }

    _initializeChildren() {
      if (!this._config.parent) {
        return;
      }

      const children = SelectorEngine.find(`.${CLASS_NAME_COLLAPSE} .${CLASS_NAME_COLLAPSE}`, this._config.parent);
      SelectorEngine.find(SELECTOR_DATA_TOGGLE$4, this._config.parent).filter(elem => !children.includes(elem)).forEach(element => {
        const selected = getElementFromSelector(element);

        if (selected) {
          this._addAriaAndCollapsedClass([element], this._isShown(selected));
        }
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      });
    }

    _addAriaAndCollapsedClass(triggerArray, isOpen) {
      if (!triggerArray.length) {
        return;
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      } else {
        parent = document.querySelector(this._config.parent);
      }

      var selector = "[data-toggle=\"collapse\"][data-parent=\"" + this._config.parent + "\"]";
      var children = [].slice.call(parent.querySelectorAll(selector));
      $__default['default'](children).each(function (i, element) {
        _this3._addAriaAndCollapsedClass(Collapse._getTargetFromElement(element), [element]);
      });
      return parent;
    };

    _proto._addAriaAndCollapsedClass = function _addAriaAndCollapsedClass(element, triggerArray) {
      var isOpen = $__default['default'](element).hasClass(CLASS_NAME_SHOW$1);

      if (triggerArray.length) {
        $__default['default'](triggerArray).toggleClass(CLASS_NAME_COLLAPSED, !isOpen).attr('aria-expanded', isOpen);
<<<<<<< HEAD
      }
    } // Static
    ;

    Collapse._getTargetFromElement = function _getTargetFromElement(element) {
      var selector = Util.getSelectorFromElement(element);
      return selector ? document.querySelector(selector) : null;
    };

    Collapse._jQueryInterface = function _jQueryInterface(config) {
      return this.each(function () {
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
      }

      triggerArray.forEach(elem => {
        if (isOpen) {
          elem.classList.remove(CLASS_NAME_COLLAPSED);
        } else {
          elem.classList.add(CLASS_NAME_COLLAPSED);
        }

        elem.setAttribute('aria-expanded', isOpen);
      });
    } // Static


    static jQueryInterface(config) {
      return this.each(function () {
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
        const _config = {};

        if (typeof config === 'string' && /show|hide/.test(config)) {
          _config.toggle = false;
        }

        const data = Collapse.getOrCreateInstance(this, _config);
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
        var $element = $__default['default'](this);
        var data = $element.data(DATA_KEY$3);

        var _config = _extends({}, Default$1, $element.data(), typeof config === 'object' && config ? config : {});

        if (!data && _config.toggle && typeof config === 'string' && /show|hide/.test(config)) {
          _config.toggle = false;
        }

        if (!data) {
          data = new Collapse(this, _config);
          $element.data(DATA_KEY$3, data);
        }
<<<<<<< HEAD

        if (typeof config === 'string') {
          if (typeof data[config] === 'undefined') {
            throw new TypeError("No method named \"" + config + "\"");
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

        if (typeof config === 'string') {
          if (typeof data[config] === 'undefined') {
            throw new TypeError(`No method named "${config}"`);
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
          }

          data[config]();
        }
      });
<<<<<<< HEAD
    };

    _createClass(Collapse, null, [{
      key: "VERSION",
      get: function get() {
        return VERSION$3;
      }
    }, {
      key: "Default",
      get: function get() {
        return Default$1;
      }
    }]);

    return Collapse;
  }();
=======
    }

  }
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  /**
   * ------------------------------------------------------------------------
   * Data Api implementation
   * ------------------------------------------------------------------------
   */


<<<<<<< HEAD
  $__default['default'](document).on(EVENT_CLICK_DATA_API$3, SELECTOR_DATA_TOGGLE$1, function (event) {
    // preventDefault only for <a> elements (which change the URL) not inside the collapsible element
    if (event.currentTarget.tagName === 'A') {
      event.preventDefault();
    }

=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  EventHandler.on(document, EVENT_CLICK_DATA_API$4, SELECTOR_DATA_TOGGLE$4, function (event) {
========
  $__default['default'](document).on(EVENT_CLICK_DATA_API$3, SELECTOR_DATA_TOGGLE$1, function (event) {
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
    // preventDefault only for <a> elements (which change the URL) not inside the collapsible element
    if (event.target.tagName === 'A' || event.delegateTarget && event.delegateTarget.tagName === 'A') {
      event.preventDefault();
    }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    const selector = getSelectorFromElement(this);
    const selectorElements = SelectorEngine.find(selector);
    selectorElements.forEach(element => {
      Collapse.getOrCreateInstance(element, {
        toggle: false
      }).toggle();
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    var $trigger = $__default['default'](this);
    var selector = Util.getSelectorFromElement(this);
    var selectors = [].slice.call(document.querySelectorAll(selector));
    $__default['default'](selectors).each(function () {
      var $target = $__default['default'](this);
      var data = $target.data(DATA_KEY$3);
      var config = data ? 'toggle' : $trigger.data();

      Collapse._jQueryInterface.call($target, config);
<<<<<<< HEAD
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    });
  });
  /**
   * ------------------------------------------------------------------------
   * jQuery
   * ------------------------------------------------------------------------
<<<<<<< HEAD
   */

=======
   * add .Collapse to jQuery only if jQuery is present
   */

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  defineJQueryPlugin(Collapse);
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  $__default['default'].fn[NAME$3] = Collapse._jQueryInterface;
  $__default['default'].fn[NAME$3].Constructor = Collapse;

  $__default['default'].fn[NAME$3].noConflict = function () {
    $__default['default'].fn[NAME$3] = JQUERY_NO_CONFLICT$3;
    return Collapse._jQueryInterface;
  };
<<<<<<< HEAD

  /**
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

  /**
   * --------------------------------------------------------------------------
   * Bootstrap (v5.1.0): dropdown.js
   * Licensed under MIT (https://github.com/twbs/bootstrap/blob/main/LICENSE)
   * --------------------------------------------------------------------------
   */
  /**
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
   * ------------------------------------------------------------------------
   * Constants
   * ------------------------------------------------------------------------
   */

<<<<<<< HEAD
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  const NAME$9 = 'dropdown';
  const DATA_KEY$8 = 'bs.dropdown';
  const EVENT_KEY$8 = `.${DATA_KEY$8}`;
  const DATA_API_KEY$4 = '.data-api';
  const ESCAPE_KEY$2 = 'Escape';
  const SPACE_KEY = 'Space';
  const TAB_KEY$1 = 'Tab';
  const ARROW_UP_KEY = 'ArrowUp';
  const ARROW_DOWN_KEY = 'ArrowDown';
  const RIGHT_MOUSE_BUTTON = 2; // MouseEvent.button value for the secondary button, usually the right button

  const REGEXP_KEYDOWN = new RegExp(`${ARROW_UP_KEY}|${ARROW_DOWN_KEY}|${ESCAPE_KEY$2}`);
  const EVENT_HIDE$4 = `hide${EVENT_KEY$8}`;
  const EVENT_HIDDEN$4 = `hidden${EVENT_KEY$8}`;
  const EVENT_SHOW$4 = `show${EVENT_KEY$8}`;
  const EVENT_SHOWN$4 = `shown${EVENT_KEY$8}`;
  const EVENT_CLICK_DATA_API$3 = `click${EVENT_KEY$8}${DATA_API_KEY$4}`;
  const EVENT_KEYDOWN_DATA_API = `keydown${EVENT_KEY$8}${DATA_API_KEY$4}`;
  const EVENT_KEYUP_DATA_API = `keyup${EVENT_KEY$8}${DATA_API_KEY$4}`;
  const CLASS_NAME_SHOW$6 = 'show';
  const CLASS_NAME_DROPUP = 'dropup';
  const CLASS_NAME_DROPEND = 'dropend';
  const CLASS_NAME_DROPSTART = 'dropstart';
  const CLASS_NAME_NAVBAR = 'navbar';
  const SELECTOR_DATA_TOGGLE$3 = '[data-bs-toggle="dropdown"]';
  const SELECTOR_MENU = '.dropdown-menu';
  const SELECTOR_NAVBAR_NAV = '.navbar-nav';
  const SELECTOR_VISIBLE_ITEMS = '.dropdown-menu .dropdown-item:not(.disabled):not(:disabled)';
  const PLACEMENT_TOP = isRTL() ? 'top-end' : 'top-start';
  const PLACEMENT_TOPEND = isRTL() ? 'top-start' : 'top-end';
  const PLACEMENT_BOTTOM = isRTL() ? 'bottom-end' : 'bottom-start';
  const PLACEMENT_BOTTOMEND = isRTL() ? 'bottom-start' : 'bottom-end';
  const PLACEMENT_RIGHT = isRTL() ? 'left-start' : 'right-start';
  const PLACEMENT_LEFT = isRTL() ? 'right-start' : 'left-start';
  const Default$8 = {
    offset: [0, 2],
    boundary: 'clippingParents',
    reference: 'toggle',
    display: 'dynamic',
    popperConfig: null,
    autoClose: true
  };
  const DefaultType$8 = {
    offset: '(array|string|function)',
    boundary: '(string|element)',
    reference: '(string|element|object)',
    display: 'string',
    popperConfig: '(null|object|function)',
    autoClose: '(boolean|string)'
  };
  /**
   * ------------------------------------------------------------------------
   * Class Definition
   * ------------------------------------------------------------------------
   */

  class Dropdown extends BaseComponent {
    constructor(element, config) {
      super(element);
      this._popper = null;
      this._config = this._getConfig(config);
      this._menu = this._getMenuElement();
      this._inNavbar = this._detectNavbar();
    } // Getters
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  var NAME$4 = 'dropdown';
  var VERSION$4 = '4.6.0';
  var DATA_KEY$4 = 'bs.dropdown';
  var EVENT_KEY$4 = "." + DATA_KEY$4;
  var DATA_API_KEY$4 = '.data-api';
  var JQUERY_NO_CONFLICT$4 = $__default['default'].fn[NAME$4];
  var ESCAPE_KEYCODE = 27; // KeyboardEvent.which value for Escape (Esc) key
<<<<<<< HEAD

  var SPACE_KEYCODE = 32; // KeyboardEvent.which value for space key

  var TAB_KEYCODE = 9; // KeyboardEvent.which value for tab key

  var ARROW_UP_KEYCODE = 38; // KeyboardEvent.which value for up arrow key

  var ARROW_DOWN_KEYCODE = 40; // KeyboardEvent.which value for down arrow key

  var RIGHT_MOUSE_BUTTON_WHICH = 3; // MouseEvent.which value for the right button (assuming a right-handed mouse)

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js


    static get Default() {
      return Default$8;
    }

    static get DefaultType() {
      return DefaultType$8;
    }

    static get NAME() {
      return NAME$9;
    } // Public


<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    toggle() {
      return this._isShown() ? this.hide() : this.show();
    }

    show() {
      if (isDisabled(this._element) || this._isShown(this._menu)) {
        return;
      }

      const relatedTarget = {
        relatedTarget: this._element
      };
      const showEvent = EventHandler.trigger(this._element, EVENT_SHOW$4, relatedTarget);

      if (showEvent.defaultPrevented) {
        return;
      }

      const parent = Dropdown.getParentFromElement(this._element); // Totally disable Popper for Dropdowns in Navbar

      if (this._inNavbar) {
        Manipulator.setDataAttribute(this._menu, 'popper', 'none');
      } else {
        this._createPopper(parent);
      } // If this is a touch-enabled device we add extra
      // empty mouseover listeners to the body's immediate children;
      // only needed because of broken event delegation on iOS
      // https://www.quirksmode.org/blog/archives/2014/02/mouse_event_bub.html


      if ('ontouchstart' in document.documentElement && !parent.closest(SELECTOR_NAVBAR_NAV)) {
        [].concat(...document.body.children).forEach(elem => EventHandler.on(elem, 'mouseover', noop));
      }

      this._element.focus();

      this._element.setAttribute('aria-expanded', true);

      this._menu.classList.add(CLASS_NAME_SHOW$6);

      this._element.classList.add(CLASS_NAME_SHOW$6);

      EventHandler.trigger(this._element, EVENT_SHOWN$4, relatedTarget);
    }

    hide() {
      if (isDisabled(this._element) || !this._isShown(this._menu)) {
        return;
      }

      const relatedTarget = {
        relatedTarget: this._element
      };

      this._completeHide(relatedTarget);
    }

    dispose() {
      if (this._popper) {
        this._popper.destroy();
      }

      super.dispose();
    }

    update() {
      this._inNavbar = this._detectNavbar();

      if (this._popper) {
        this._popper.update();
      }
    } // Private


    _completeHide(relatedTarget) {
      const hideEvent = EventHandler.trigger(this._element, EVENT_HIDE$4, relatedTarget);

      if (hideEvent.defaultPrevented) {
        return;
      } // If this is a touch-enabled device we remove the extra
      // empty mouseover listeners we added for iOS support


      if ('ontouchstart' in document.documentElement) {
        [].concat(...document.body.children).forEach(elem => EventHandler.off(elem, 'mouseover', noop));
      }

      if (this._popper) {
        this._popper.destroy();
      }

      this._menu.classList.remove(CLASS_NAME_SHOW$6);

      this._element.classList.remove(CLASS_NAME_SHOW$6);

      this._element.setAttribute('aria-expanded', 'false');

      Manipulator.removeDataAttribute(this._menu, 'popper');
      EventHandler.trigger(this._element, EVENT_HIDDEN$4, relatedTarget);
    }

    _getConfig(config) {
      config = { ...this.constructor.Default,
        ...Manipulator.getDataAttributes(this._element),
        ...config
      };
      typeCheckConfig(NAME$9, config, this.constructor.DefaultType);

      if (typeof config.reference === 'object' && !isElement(config.reference) && typeof config.reference.getBoundingClientRect !== 'function') {
        // Popper virtual elements require a getBoundingClientRect method
        throw new TypeError(`${NAME$9.toUpperCase()}: Option "reference" provided type "object" without a required "getBoundingClientRect" method.`);
      }

      return config;
    }

    _createPopper(parent) {
      if (typeof Popper__namespace === 'undefined') {
        throw new TypeError('Bootstrap\'s dropdowns require Popper (https://popper.js.org)');
      }

      let referenceElement = this._element;

      if (this._config.reference === 'parent') {
        referenceElement = parent;
      } else if (isElement(this._config.reference)) {
        referenceElement = getElement(this._config.reference);
      } else if (typeof this._config.reference === 'object') {
        referenceElement = this._config.reference;
      }

      const popperConfig = this._getPopperConfig();

      const isDisplayStatic = popperConfig.modifiers.find(modifier => modifier.name === 'applyStyles' && modifier.enabled === false);
      this._popper = Popper__namespace.createPopper(referenceElement, this._menu, popperConfig);

      if (isDisplayStatic) {
        Manipulator.setDataAttribute(this._menu, 'popper', 'static');
      }
    }

    _isShown(element = this._element) {
      return element.classList.contains(CLASS_NAME_SHOW$6);
    }

    _getMenuElement() {
      return SelectorEngine.next(this._element, SELECTOR_MENU)[0];
    }

    _getPlacement() {
      const parentDropdown = this._element.parentNode;

      if (parentDropdown.classList.contains(CLASS_NAME_DROPEND)) {
        return PLACEMENT_RIGHT;
      }

      if (parentDropdown.classList.contains(CLASS_NAME_DROPSTART)) {
        return PLACEMENT_LEFT;
      } // We need to trim the value because custom properties can also include spaces


      const isEnd = getComputedStyle(this._menu).getPropertyValue('--bs-position').trim() === 'end';

      if (parentDropdown.classList.contains(CLASS_NAME_DROPUP)) {
        return isEnd ? PLACEMENT_TOPEND : PLACEMENT_TOP;
      }

      return isEnd ? PLACEMENT_BOTTOMEND : PLACEMENT_BOTTOM;
    }

    _detectNavbar() {
      return this._element.closest(`.${CLASS_NAME_NAVBAR}`) !== null;
    }

    _getOffset() {
      const {
        offset
      } = this._config;

      if (typeof offset === 'string') {
        return offset.split(',').map(val => Number.parseInt(val, 10));
      }

      if (typeof offset === 'function') {
        return popperData => offset(popperData, this._element);
      }

      return offset;
    }

    _getPopperConfig() {
      const defaultBsPopperConfig = {
        placement: this._getPlacement(),
        modifiers: [{
          name: 'preventOverflow',
          options: {
            boundary: this._config.boundary
          }
        }, {
          name: 'offset',
          options: {
            offset: this._getOffset()
          }
        }]
      }; // Disable Popper if we have a static display

      if (this._config.display === 'static') {
        defaultBsPopperConfig.modifiers = [{
          name: 'applyStyles',
          enabled: false
        }];
      }

      return { ...defaultBsPopperConfig,
        ...(typeof this._config.popperConfig === 'function' ? this._config.popperConfig(defaultBsPopperConfig) : this._config.popperConfig)
      };
    }

    _selectMenuItem({
      key,
      target
    }) {
      const items = SelectorEngine.find(SELECTOR_VISIBLE_ITEMS, this._menu).filter(isVisible);
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  var REGEXP_KEYDOWN = new RegExp(ARROW_UP_KEYCODE + "|" + ARROW_DOWN_KEYCODE + "|" + ESCAPE_KEYCODE);
  var EVENT_HIDE$1 = "hide" + EVENT_KEY$4;
  var EVENT_HIDDEN$1 = "hidden" + EVENT_KEY$4;
  var EVENT_SHOW$1 = "show" + EVENT_KEY$4;
  var EVENT_SHOWN$1 = "shown" + EVENT_KEY$4;
  var EVENT_CLICK = "click" + EVENT_KEY$4;
  var EVENT_CLICK_DATA_API$4 = "click" + EVENT_KEY$4 + DATA_API_KEY$4;
  var EVENT_KEYDOWN_DATA_API = "keydown" + EVENT_KEY$4 + DATA_API_KEY$4;
  var EVENT_KEYUP_DATA_API = "keyup" + EVENT_KEY$4 + DATA_API_KEY$4;
  var CLASS_NAME_DISABLED = 'disabled';
  var CLASS_NAME_SHOW$2 = 'show';
  var CLASS_NAME_DROPUP = 'dropup';
  var CLASS_NAME_DROPRIGHT = 'dropright';
  var CLASS_NAME_DROPLEFT = 'dropleft';
  var CLASS_NAME_MENURIGHT = 'dropdown-menu-right';
  var CLASS_NAME_POSITION_STATIC = 'position-static';
  var SELECTOR_DATA_TOGGLE$2 = '[data-toggle="dropdown"]';
  var SELECTOR_FORM_CHILD = '.dropdown form';
  var SELECTOR_MENU = '.dropdown-menu';
  var SELECTOR_NAVBAR_NAV = '.navbar-nav';
  var SELECTOR_VISIBLE_ITEMS = '.dropdown-menu .dropdown-item:not(.disabled):not(:disabled)';
  var PLACEMENT_TOP = 'top-start';
  var PLACEMENT_TOPEND = 'top-end';
  var PLACEMENT_BOTTOM = 'bottom-start';
  var PLACEMENT_BOTTOMEND = 'bottom-end';
  var PLACEMENT_RIGHT = 'right-start';
  var PLACEMENT_LEFT = 'left-start';
  var Default$2 = {
    offset: 0,
    flip: true,
    boundary: 'scrollParent',
    reference: 'toggle',
    display: 'dynamic',
    popperConfig: null
  };
  var DefaultType$2 = {
    offset: '(number|string|function)',
    flip: 'boolean',
    boundary: '(string|element)',
    reference: '(string|element)',
    display: 'string',
    popperConfig: '(null|object)'
  };
  /**
   * ------------------------------------------------------------------------
   * Class Definition
   * ------------------------------------------------------------------------
   */

  var Dropdown = /*#__PURE__*/function () {
    function Dropdown(element, config) {
      this._element = element;
      this._popper = null;
      this._config = this._getConfig(config);
      this._menu = this._getMenuElement();
      this._inNavbar = this._detectNavbar();
<<<<<<< HEAD

      this._addEventListeners();
    } // Getters


    var _proto = Dropdown.prototype;

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

      if (!items.length) {
        return;
      } // if target isn't included in items (e.g. when expanding the dropdown)
      // allow cycling to get the last item in case key equals ARROW_UP_KEY


      getNextActiveElement(items, target, key === ARROW_DOWN_KEY, !items.includes(target)).focus();
    } // Static

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js

    static jQueryInterface(config) {
      return this.each(function () {
        const data = Dropdown.getOrCreateInstance(this, config);

        if (typeof config !== 'string') {
          return;
        }

        if (typeof data[config] === 'undefined') {
          throw new TypeError(`No method named "${config}"`);
        }
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    // Public
    _proto.toggle = function toggle() {
      if (this._element.disabled || $__default['default'](this._element).hasClass(CLASS_NAME_DISABLED)) {
        return;
      }

      var isActive = $__default['default'](this._menu).hasClass(CLASS_NAME_SHOW$2);
<<<<<<< HEAD

      Dropdown._clearMenus();

      if (isActive) {
        return;
      }

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

        data[config]();
      });
    }

    static clearMenus(event) {
      if (event && (event.button === RIGHT_MOUSE_BUTTON || event.type === 'keyup' && event.key !== TAB_KEY$1)) {
        return;
      }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      const toggles = SelectorEngine.find(SELECTOR_DATA_TOGGLE$3);
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      this.show(true);
    };

    _proto.show = function show(usePopper) {
      if (usePopper === void 0) {
        usePopper = false;
      }

      if (this._element.disabled || $__default['default'](this._element).hasClass(CLASS_NAME_DISABLED) || $__default['default'](this._menu).hasClass(CLASS_NAME_SHOW$2)) {
        return;
      }

      var relatedTarget = {
        relatedTarget: this._element
      };
      var showEvent = $__default['default'].Event(EVENT_SHOW$1, relatedTarget);

      var parent = Dropdown._getParentFromElement(this._element);

      $__default['default'](parent).trigger(showEvent);

      if (showEvent.isDefaultPrevented()) {
        return;
      } // Totally disable Popper for Dropdowns in Navbar
<<<<<<< HEAD


=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

      for (let i = 0, len = toggles.length; i < len; i++) {
        const context = Dropdown.getInstance(toggles[i]);

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
        if (!context || context._config.autoClose === false) {
          continue;
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      if (!this._inNavbar && usePopper) {
        /**
         * Check for Popper dependency
         * Popper - https://popper.js.org
         */
        if (typeof Popper__default['default'] === 'undefined') {
          throw new TypeError('Bootstrap\'s dropdowns require Popper (https://popper.js.org)');
<<<<<<< HEAD
        }

        var referenceElement = this._element;

        if (this._config.reference === 'parent') {
          referenceElement = parent;
        } else if (Util.isElement(this._config.reference)) {
          referenceElement = this._config.reference; // Check if it's jQuery element

          if (typeof this._config.reference.jquery !== 'undefined') {
            referenceElement = this._config.reference[0];
          }
        } // If boundary is not `scrollParent`, then set position to `static`
        // to allow the menu to "escape" the scroll parent's boundaries
        // https://github.com/twbs/bootstrap/issues/24251


=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
        }

        if (!context._isShown()) {
          continue;
        }

        const relatedTarget = {
          relatedTarget: context._element
        };

        if (event) {
          const composedPath = event.composedPath();
          const isMenuTarget = composedPath.includes(context._menu);

          if (composedPath.includes(context._element) || context._config.autoClose === 'inside' && !isMenuTarget || context._config.autoClose === 'outside' && isMenuTarget) {
            continue;
          } // Tab navigation through the dropdown menu or events from contained inputs shouldn't close the menu

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js

          if (context._menu.contains(event.target) && (event.type === 'keyup' && event.key === TAB_KEY$1 || /input|select|option|textarea|form/i.test(event.target.tagName))) {
            continue;
          }
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
        if (this._config.boundary !== 'scrollParent') {
          $__default['default'](parent).addClass(CLASS_NAME_POSITION_STATIC);
        }

        this._popper = new Popper__default['default'](referenceElement, this._menu, this._getPopperConfig());
      } // If this is a touch-enabled device we add extra
      // empty mouseover listeners to the body's immediate children;
      // only needed because of broken event delegation on iOS
      // https://www.quirksmode.org/blog/archives/2014/02/mouse_event_bub.html
<<<<<<< HEAD


      if ('ontouchstart' in document.documentElement && $__default['default'](parent).closest(SELECTOR_NAVBAR_NAV).length === 0) {
        $__default['default'](document.body).children().on('mouseover', null, $__default['default'].noop);
      }

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

          if (event.type === 'click') {
            relatedTarget.clickEvent = event;
          }
        }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
        context._completeHide(relatedTarget);
========
      if ('ontouchstart' in document.documentElement && $__default['default'](parent).closest(SELECTOR_NAVBAR_NAV).length === 0) {
        $__default['default'](document.body).children().on('mouseover', null, $__default['default'].noop);
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
      }
    }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    static getParentFromElement(element) {
      return getElementFromSelector(element) || element.parentNode;
    }

    static dataApiKeydownHandler(event) {
      // If not input/textarea:
      //  - And not a key in REGEXP_KEYDOWN => not a dropdown command
      // If input/textarea:
      //  - If space key => not a dropdown command
      //  - If key is other than escape
      //    - If key is not up or down => not a dropdown command
      //    - If trigger inside the menu => not a dropdown command
      if (/input|textarea/i.test(event.target.tagName) ? event.key === SPACE_KEY || event.key !== ESCAPE_KEY$2 && (event.key !== ARROW_DOWN_KEY && event.key !== ARROW_UP_KEY || event.target.closest(SELECTOR_MENU)) : !REGEXP_KEYDOWN.test(event.key)) {
        return;
      }

      const isActive = this.classList.contains(CLASS_NAME_SHOW$6);

      if (!isActive && event.key === ESCAPE_KEY$2) {
        return;
      }

      event.preventDefault();
      event.stopPropagation();

      if (isDisabled(this)) {
        return;
      }

      const getToggleButton = this.matches(SELECTOR_DATA_TOGGLE$3) ? this : SelectorEngine.prev(this, SELECTOR_DATA_TOGGLE$3)[0];
      const instance = Dropdown.getOrCreateInstance(getToggleButton);

      if (event.key === ESCAPE_KEY$2) {
        instance.hide();
        return;
      }

      if (event.key === ARROW_UP_KEY || event.key === ARROW_DOWN_KEY) {
        if (!isActive) {
          instance.show();
        }

        instance._selectMenuItem(event);
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      this._element.focus();

      this._element.setAttribute('aria-expanded', true);

      $__default['default'](this._menu).toggleClass(CLASS_NAME_SHOW$2);
      $__default['default'](parent).toggleClass(CLASS_NAME_SHOW$2).trigger($__default['default'].Event(EVENT_SHOWN$1, relatedTarget));
    };

    _proto.hide = function hide() {
      if (this._element.disabled || $__default['default'](this._element).hasClass(CLASS_NAME_DISABLED) || !$__default['default'](this._menu).hasClass(CLASS_NAME_SHOW$2)) {
        return;
      }

      var relatedTarget = {
        relatedTarget: this._element
      };
      var hideEvent = $__default['default'].Event(EVENT_HIDE$1, relatedTarget);

      var parent = Dropdown._getParentFromElement(this._element);

      $__default['default'](parent).trigger(hideEvent);
<<<<<<< HEAD

      if (hideEvent.isDefaultPrevented()) {
        return;
      }

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

        return;
      }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      if (!isActive || event.key === SPACE_KEY) {
        Dropdown.clearMenus();
      }
    }

  }
  /**
   * ------------------------------------------------------------------------
   * Data Api implementation
   * ------------------------------------------------------------------------
   */
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      if (this._popper) {
        this._popper.destroy();
      }

      $__default['default'](this._menu).toggleClass(CLASS_NAME_SHOW$2);
      $__default['default'](parent).toggleClass(CLASS_NAME_SHOW$2).trigger($__default['default'].Event(EVENT_HIDDEN$1, relatedTarget));
    };

    _proto.dispose = function dispose() {
      $__default['default'].removeData(this._element, DATA_KEY$4);
      $__default['default'](this._element).off(EVENT_KEY$4);
      this._element = null;
      this._menu = null;
<<<<<<< HEAD

      if (this._popper !== null) {
        this._popper.destroy();

        this._popper = null;
      }
    };

    _proto.update = function update() {
      this._inNavbar = this._detectNavbar();

      if (this._popper !== null) {
        this._popper.scheduleUpdate();
      }
    } // Private
    ;

    _proto._addEventListeners = function _addEventListeners() {
      var _this = this;

      $__default['default'](this._element).on(EVENT_CLICK, function (event) {
        event.preventDefault();
        event.stopPropagation();

        _this.toggle();
      });
    };

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js


  EventHandler.on(document, EVENT_KEYDOWN_DATA_API, SELECTOR_DATA_TOGGLE$3, Dropdown.dataApiKeydownHandler);
  EventHandler.on(document, EVENT_KEYDOWN_DATA_API, SELECTOR_MENU, Dropdown.dataApiKeydownHandler);
  EventHandler.on(document, EVENT_CLICK_DATA_API$3, Dropdown.clearMenus);
  EventHandler.on(document, EVENT_KEYUP_DATA_API, Dropdown.clearMenus);
  EventHandler.on(document, EVENT_CLICK_DATA_API$3, SELECTOR_DATA_TOGGLE$3, function (event) {
    event.preventDefault();
    Dropdown.getOrCreateInstance(this).toggle();
  });
  /**
   * ------------------------------------------------------------------------
   * jQuery
   * ------------------------------------------------------------------------
   * add .Dropdown to jQuery only if jQuery is present
   */

  defineJQueryPlugin(Dropdown);

  /**
   * --------------------------------------------------------------------------
   * Bootstrap (v5.1.0): util/scrollBar.js
   * Licensed under MIT (https://github.com/twbs/bootstrap/blob/main/LICENSE)
   * --------------------------------------------------------------------------
   */
  const SELECTOR_FIXED_CONTENT = '.fixed-top, .fixed-bottom, .is-fixed, .sticky-top';
  const SELECTOR_STICKY_CONTENT = '.sticky-top';

  class ScrollBarHelper {
    constructor() {
      this._element = document.body;
    }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    getWidth() {
      // https://developer.mozilla.org/en-US/docs/Web/API/Window/innerWidth#usage_notes
      const documentWidth = document.documentElement.clientWidth;
      return Math.abs(window.innerWidth - documentWidth);
    }
========
      $__default['default'](this._element).on(EVENT_CLICK, function (event) {
        event.preventDefault();
        event.stopPropagation();
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

    hide() {
      const width = this.getWidth();

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      this._disableOverFlow(); // give padding to element to balance the hidden scrollbar width
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    _proto._getConfig = function _getConfig(config) {
      config = _extends({}, this.constructor.Default, $__default['default'](this._element).data(), config);
      Util.typeCheckConfig(NAME$4, config, this.constructor.DefaultType);
      return config;
    };
<<<<<<< HEAD

    _proto._getMenuElement = function _getMenuElement() {
      if (!this._menu) {
        var parent = Dropdown._getParentFromElement(this._element);

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js


<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      this._setElementAttributes(this._element, 'paddingRight', calculatedValue => calculatedValue + width); // trick: We adjust positive paddingRight and negative marginRight to sticky-top elements to keep showing fullwidth
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
        if (parent) {
          this._menu = parent.querySelector(SELECTOR_MENU);
        }
      }
<<<<<<< HEAD

      return this._menu;
    };

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js


<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      this._setElementAttributes(SELECTOR_FIXED_CONTENT, 'paddingRight', calculatedValue => calculatedValue + width);

      this._setElementAttributes(SELECTOR_STICKY_CONTENT, 'marginRight', calculatedValue => calculatedValue - width);
    }

    _disableOverFlow() {
      this._saveInitialAttribute(this._element, 'overflow');

      this._element.style.overflow = 'hidden';
    }

    _setElementAttributes(selector, styleProp, callback) {
      const scrollbarWidth = this.getWidth();

      const manipulationCallBack = element => {
        if (element !== this._element && window.innerWidth > element.clientWidth + scrollbarWidth) {
          return;
        }
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    _proto._getPlacement = function _getPlacement() {
      var $parentDropdown = $__default['default'](this._element.parentNode);
      var placement = PLACEMENT_BOTTOM; // Handle dropup

      if ($parentDropdown.hasClass(CLASS_NAME_DROPUP)) {
        placement = $__default['default'](this._menu).hasClass(CLASS_NAME_MENURIGHT) ? PLACEMENT_TOPEND : PLACEMENT_TOP;
      } else if ($parentDropdown.hasClass(CLASS_NAME_DROPRIGHT)) {
        placement = PLACEMENT_RIGHT;
      } else if ($parentDropdown.hasClass(CLASS_NAME_DROPLEFT)) {
        placement = PLACEMENT_LEFT;
      } else if ($__default['default'](this._menu).hasClass(CLASS_NAME_MENURIGHT)) {
        placement = PLACEMENT_BOTTOMEND;
      }
<<<<<<< HEAD

      return placement;
    };

    _proto._detectNavbar = function _detectNavbar() {
      return $__default['default'](this._element).closest('.navbar').length > 0;
    };

    _proto._getOffset = function _getOffset() {
      var _this2 = this;

      var offset = {};

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

        this._saveInitialAttribute(element, styleProp);

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
        const calculatedValue = window.getComputedStyle(element)[styleProp];
        element.style[styleProp] = `${callback(Number.parseFloat(calculatedValue))}px`;
      };
========
    _proto._detectNavbar = function _detectNavbar() {
      return $__default['default'](this._element).closest('.navbar').length > 0;
    };
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

      this._applyManipulationCallback(selector, manipulationCallBack);
    }

    reset() {
      this._resetElementAttributes(this._element, 'overflow');

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      this._resetElementAttributes(this._element, 'paddingRight');
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      if (typeof this._config.offset === 'function') {
        offset.fn = function (data) {
          data.offsets = _extends({}, data.offsets, _this2._config.offset(data.offsets, _this2._element) || {});
          return data;
        };
      } else {
        offset.offset = this._config.offset;
      }
<<<<<<< HEAD

      return offset;
    };

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

      this._resetElementAttributes(SELECTOR_FIXED_CONTENT, 'paddingRight');

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      this._resetElementAttributes(SELECTOR_STICKY_CONTENT, 'marginRight');
    }

    _saveInitialAttribute(element, styleProp) {
      const actualValue = element.style[styleProp];
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    _proto._getPopperConfig = function _getPopperConfig() {
      var popperConfig = {
        placement: this._getPlacement(),
        modifiers: {
          offset: this._getOffset(),
          flip: {
            enabled: this._config.flip
          },
          preventOverflow: {
            boundariesElement: this._config.boundary
          }
        }
      }; // Disable Popper if we have a static display
<<<<<<< HEAD

      if (this._config.display === 'static') {
        popperConfig.modifiers.applyStyle = {
          enabled: false
        };
      }

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

      if (actualValue) {
        Manipulator.setDataAttribute(element, styleProp, actualValue);
      }
    }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    _resetElementAttributes(selector, styleProp) {
      const manipulationCallBack = element => {
        const value = Manipulator.getDataAttribute(element, styleProp);

        if (typeof value === 'undefined') {
          element.style.removeProperty(styleProp);
        } else {
          Manipulator.removeDataAttribute(element, styleProp);
          element.style[styleProp] = value;
        }
      };
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      return _extends({}, popperConfig, this._config.popperConfig);
    } // Static
    ;

    Dropdown._jQueryInterface = function _jQueryInterface(config) {
      return this.each(function () {
        var data = $__default['default'](this).data(DATA_KEY$4);
<<<<<<< HEAD

        var _config = typeof config === 'object' ? config : null;

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

      this._applyManipulationCallback(selector, manipulationCallBack);
    }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    _applyManipulationCallback(selector, callBack) {
      if (isElement(selector)) {
        callBack(selector);
      } else {
        SelectorEngine.find(selector, this._element).forEach(callBack);
      }
    }
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
        if (!data) {
          data = new Dropdown(this, _config);
          $__default['default'](this).data(DATA_KEY$4, data);
        }
<<<<<<< HEAD

        if (typeof config === 'string') {
          if (typeof data[config] === 'undefined') {
            throw new TypeError("No method named \"" + config + "\"");
          }

          data[config]();
        }
      });
    };

    Dropdown._clearMenus = function _clearMenus(event) {
      if (event && (event.which === RIGHT_MOUSE_BUTTON_WHICH || event.type === 'keyup' && event.which !== TAB_KEYCODE)) {
        return;
      }

      var toggles = [].slice.call(document.querySelectorAll(SELECTOR_DATA_TOGGLE$2));

      for (var i = 0, len = toggles.length; i < len; i++) {
        var parent = Dropdown._getParentFromElement(toggles[i]);

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

    isOverflowing() {
      return this.getWidth() > 0;
    }

  }

  /**
   * --------------------------------------------------------------------------
   * Bootstrap (v5.1.0): util/backdrop.js
   * Licensed under MIT (https://github.com/twbs/bootstrap/blob/master/LICENSE)
   * --------------------------------------------------------------------------
   */
  const Default$7 = {
    className: 'modal-backdrop',
    isVisible: true,
    // if false, we use the backdrop helper without adding any element to the dom
    isAnimated: false,
    rootElement: 'body',
    // give the choice to place backdrop under different elements
    clickCallback: null
  };
  const DefaultType$7 = {
    className: 'string',
    isVisible: 'boolean',
    isAnimated: 'boolean',
    rootElement: '(element|string)',
    clickCallback: '(function|null)'
  };
  const NAME$8 = 'backdrop';
  const CLASS_NAME_FADE$4 = 'fade';
  const CLASS_NAME_SHOW$5 = 'show';
  const EVENT_MOUSEDOWN = `mousedown.bs.${NAME$8}`;

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  class Backdrop {
    constructor(config) {
      this._config = this._getConfig(config);
      this._isAppended = false;
      this._element = null;
    }
========
      var toggles = [].slice.call(document.querySelectorAll(SELECTOR_DATA_TOGGLE$2));
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

    show(callback) {
      if (!this._config.isVisible) {
        execute(callback);
        return;
      }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      this._append();
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
        var context = $__default['default'](toggles[i]).data(DATA_KEY$4);
        var relatedTarget = {
          relatedTarget: toggles[i]
        };
<<<<<<< HEAD

        if (event && event.type === 'click') {
          relatedTarget.clickEvent = event;
        }

        if (!context) {
          continue;
        }

        var dropdownMenu = context._menu;

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

      if (this._config.isAnimated) {
        reflow(this._getElement());
      }

      this._getElement().classList.add(CLASS_NAME_SHOW$5);

      this._emulateAnimation(() => {
        execute(callback);
      });
    }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    hide(callback) {
      if (!this._config.isVisible) {
        execute(callback);
        return;
      }

      this._getElement().classList.remove(CLASS_NAME_SHOW$5);

      this._emulateAnimation(() => {
        this.dispose();
        execute(callback);
      });
    } // Private
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
        if (!$__default['default'](parent).hasClass(CLASS_NAME_SHOW$2)) {
          continue;
        }

        if (event && (event.type === 'click' && /input|textarea/i.test(event.target.tagName) || event.type === 'keyup' && event.which === TAB_KEYCODE) && $__default['default'].contains(parent, event.target)) {
          continue;
        }

        var hideEvent = $__default['default'].Event(EVENT_HIDE$1, relatedTarget);
        $__default['default'](parent).trigger(hideEvent);
<<<<<<< HEAD

        if (hideEvent.isDefaultPrevented()) {
          continue;
        } // If this is a touch-enabled device we remove the extra
        // empty mouseover listeners we added for iOS support


=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js


    _getElement() {
      if (!this._element) {
        const backdrop = document.createElement('div');
        backdrop.className = this._config.className;

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
        if (this._config.isAnimated) {
          backdrop.classList.add(CLASS_NAME_FADE$4);
        }

        this._element = backdrop;
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
        if ('ontouchstart' in document.documentElement) {
          $__default['default'](document.body).children().off('mouseover', null, $__default['default'].noop);
        }

        toggles[i].setAttribute('aria-expanded', 'false');

        if (context._popper) {
          context._popper.destroy();
        }

        $__default['default'](dropdownMenu).removeClass(CLASS_NAME_SHOW$2);
        $__default['default'](parent).removeClass(CLASS_NAME_SHOW$2).trigger($__default['default'].Event(EVENT_HIDDEN$1, relatedTarget));
<<<<<<< HEAD
      }
    };

    Dropdown._getParentFromElement = function _getParentFromElement(element) {
      var parent;
      var selector = Util.getSelectorFromElement(element);

      if (selector) {
        parent = document.querySelector(selector);
      }

      return parent || element.parentNode;
    } // eslint-disable-next-line complexity
    ;

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
      }

      return this._element;
    }

    _getConfig(config) {
      config = { ...Default$7,
        ...(typeof config === 'object' ? config : {})
      }; // use getElement() with the default "body" to get a fresh Element on each instantiation

      config.rootElement = getElement(config.rootElement);
      typeCheckConfig(NAME$8, config, DefaultType$7);
      return config;
    }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    _append() {
      if (this._isAppended) {
        return;
      }

      this._config.rootElement.append(this._getElement());

      EventHandler.on(this._getElement(), EVENT_MOUSEDOWN, () => {
        execute(this._config.clickCallback);
      });
      this._isAppended = true;
    }

    dispose() {
      if (!this._isAppended) {
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    Dropdown._dataApiKeydownHandler = function _dataApiKeydownHandler(event) {
      // If not input/textarea:
      //  - And not a key in REGEXP_KEYDOWN => not a dropdown command
      // If input/textarea:
      //  - If space key => not a dropdown command
      //  - If key is other than escape
      //    - If key is not up or down => not a dropdown command
      //    - If trigger inside the menu => not a dropdown command
      if (/input|textarea/i.test(event.target.tagName) ? event.which === SPACE_KEYCODE || event.which !== ESCAPE_KEYCODE && (event.which !== ARROW_DOWN_KEYCODE && event.which !== ARROW_UP_KEYCODE || $__default['default'](event.target).closest(SELECTOR_MENU).length) : !REGEXP_KEYDOWN.test(event.which)) {
        return;
      }

      if (this.disabled || $__default['default'](this).hasClass(CLASS_NAME_DISABLED)) {
<<<<<<< HEAD
        return;
      }

      var parent = Dropdown._getParentFromElement(this);

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
        return;
      }

      EventHandler.off(this._element, EVENT_MOUSEDOWN);

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      this._element.remove();

      this._isAppended = false;
    }

    _emulateAnimation(callback) {
      executeAfterTransition(callback, this._getElement(), this._config.isAnimated);
    }

  }

  /**
   * --------------------------------------------------------------------------
   * Bootstrap (v5.1.0): util/focustrap.js
   * Licensed under MIT (https://github.com/twbs/bootstrap/blob/master/LICENSE)
   * --------------------------------------------------------------------------
   */
  const Default$6 = {
    trapElement: null,
    // The element to trap focus inside of
    autofocus: true
  };
  const DefaultType$6 = {
    trapElement: 'element',
    autofocus: 'boolean'
  };
  const NAME$7 = 'focustrap';
  const DATA_KEY$7 = 'bs.focustrap';
  const EVENT_KEY$7 = `.${DATA_KEY$7}`;
  const EVENT_FOCUSIN$1 = `focusin${EVENT_KEY$7}`;
  const EVENT_KEYDOWN_TAB = `keydown.tab${EVENT_KEY$7}`;
  const TAB_KEY = 'Tab';
  const TAB_NAV_FORWARD = 'forward';
  const TAB_NAV_BACKWARD = 'backward';

  class FocusTrap {
    constructor(config) {
      this._config = this._getConfig(config);
      this._isActive = false;
      this._lastTabNavDirection = null;
    }

    activate() {
      const {
        trapElement,
        autofocus
      } = this._config;

      if (this._isActive) {
        return;
      }

      if (autofocus) {
        trapElement.focus();
      }

      EventHandler.off(document, EVENT_KEY$7); // guard against infinite focus loop

      EventHandler.on(document, EVENT_FOCUSIN$1, event => this._handleFocusin(event));
      EventHandler.on(document, EVENT_KEYDOWN_TAB, event => this._handleKeydown(event));
      this._isActive = true;
    }
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      var isActive = $__default['default'](parent).hasClass(CLASS_NAME_SHOW$2);

      if (!isActive && event.which === ESCAPE_KEYCODE) {
        return;
      }

      event.preventDefault();
      event.stopPropagation();

      if (!isActive || event.which === ESCAPE_KEYCODE || event.which === SPACE_KEYCODE) {
        if (event.which === ESCAPE_KEYCODE) {
          $__default['default'](parent.querySelector(SELECTOR_DATA_TOGGLE$2)).trigger('focus');
        }

        $__default['default'](this).trigger('click');
        return;
      }

      var items = [].slice.call(parent.querySelectorAll(SELECTOR_VISIBLE_ITEMS)).filter(function (item) {
        return $__default['default'](item).is(':visible');
      });
<<<<<<< HEAD

      if (items.length === 0) {
        return;
      }

      var index = items.indexOf(event.target);

      if (event.which === ARROW_UP_KEYCODE && index > 0) {
        // Up
        index--;
      }

      if (event.which === ARROW_DOWN_KEYCODE && index < items.length - 1) {
        // Down
        index++;
      }

      if (index < 0) {
        index = 0;
      }

      items[index].focus();
    };

    _createClass(Dropdown, null, [{
      key: "VERSION",
      get: function get() {
        return VERSION$4;
      }
    }, {
      key: "Default",
      get: function get() {
        return Default$2;
      }
    }, {
      key: "DefaultType",
      get: function get() {
        return DefaultType$2;
      }
    }]);

    return Dropdown;
  }();
  /**
   * ------------------------------------------------------------------------
   * Data Api implementation
   * ------------------------------------------------------------------------
   */


=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

    deactivate() {
      if (!this._isActive) {
        return;
      }

      this._isActive = false;
      EventHandler.off(document, EVENT_KEY$7);
    } // Private


    _handleFocusin(event) {
      const {
        target
      } = event;
      const {
        trapElement
      } = this._config;

      if (target === document || target === trapElement || trapElement.contains(target)) {
        return;
      }

      const elements = SelectorEngine.focusableChildren(trapElement);

      if (elements.length === 0) {
        trapElement.focus();
      } else if (this._lastTabNavDirection === TAB_NAV_BACKWARD) {
        elements[elements.length - 1].focus();
      } else {
        elements[0].focus();
      }
    }

    _handleKeydown(event) {
      if (event.key !== TAB_KEY) {
        return;
      }

      this._lastTabNavDirection = event.shiftKey ? TAB_NAV_BACKWARD : TAB_NAV_FORWARD;
    }

    _getConfig(config) {
      config = { ...Default$6,
        ...(typeof config === 'object' ? config : {})
      };
      typeCheckConfig(NAME$7, config, DefaultType$6);
      return config;
    }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  }

========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  $__default['default'](document).on(EVENT_KEYDOWN_DATA_API, SELECTOR_DATA_TOGGLE$2, Dropdown._dataApiKeydownHandler).on(EVENT_KEYDOWN_DATA_API, SELECTOR_MENU, Dropdown._dataApiKeydownHandler).on(EVENT_CLICK_DATA_API$4 + " " + EVENT_KEYUP_DATA_API, Dropdown._clearMenus).on(EVENT_CLICK_DATA_API$4, SELECTOR_DATA_TOGGLE$2, function (event) {
    event.preventDefault();
    event.stopPropagation();

    Dropdown._jQueryInterface.call($__default['default'](this), 'toggle');
  }).on(EVENT_CLICK_DATA_API$4, SELECTOR_FORM_CHILD, function (e) {
    e.stopPropagation();
  });
<<<<<<< HEAD
  /**
   * ------------------------------------------------------------------------
   * jQuery
   * ------------------------------------------------------------------------
   */
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
  /**
   * --------------------------------------------------------------------------
   * Bootstrap (v5.1.0): modal.js
   * Licensed under MIT (https://github.com/twbs/bootstrap/blob/main/LICENSE)
   * --------------------------------------------------------------------------
   */
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277

  $__default['default'].fn[NAME$4] = Dropdown._jQueryInterface;
  $__default['default'].fn[NAME$4].Constructor = Dropdown;

  $__default['default'].fn[NAME$4].noConflict = function () {
    $__default['default'].fn[NAME$4] = JQUERY_NO_CONFLICT$4;
    return Dropdown._jQueryInterface;
  };

<<<<<<< HEAD
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  /**
   * ------------------------------------------------------------------------
   * Constants
   * ------------------------------------------------------------------------
   */

<<<<<<< HEAD
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  const NAME$6 = 'modal';
  const DATA_KEY$6 = 'bs.modal';
  const EVENT_KEY$6 = `.${DATA_KEY$6}`;
  const DATA_API_KEY$3 = '.data-api';
  const ESCAPE_KEY$1 = 'Escape';
  const Default$5 = {
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  var NAME$5 = 'modal';
  var VERSION$5 = '4.6.0';
  var DATA_KEY$5 = 'bs.modal';
  var EVENT_KEY$5 = "." + DATA_KEY$5;
  var DATA_API_KEY$5 = '.data-api';
  var JQUERY_NO_CONFLICT$5 = $__default['default'].fn[NAME$5];
  var ESCAPE_KEYCODE$1 = 27; // KeyboardEvent.which value for Escape (Esc) key

  var Default$3 = {
<<<<<<< HEAD
    backdrop: true,
    keyboard: true,
    focus: true,
    show: true
  };
  var DefaultType$3 = {
    backdrop: '(boolean|string)',
    keyboard: 'boolean',
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
    backdrop: true,
    keyboard: true,
    focus: true
  };
  const DefaultType$5 = {
    backdrop: '(boolean|string)',
    keyboard: 'boolean',
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    focus: 'boolean'
  };
  const EVENT_HIDE$3 = `hide${EVENT_KEY$6}`;
  const EVENT_HIDE_PREVENTED = `hidePrevented${EVENT_KEY$6}`;
  const EVENT_HIDDEN$3 = `hidden${EVENT_KEY$6}`;
  const EVENT_SHOW$3 = `show${EVENT_KEY$6}`;
  const EVENT_SHOWN$3 = `shown${EVENT_KEY$6}`;
  const EVENT_RESIZE = `resize${EVENT_KEY$6}`;
  const EVENT_CLICK_DISMISS = `click.dismiss${EVENT_KEY$6}`;
  const EVENT_KEYDOWN_DISMISS$1 = `keydown.dismiss${EVENT_KEY$6}`;
  const EVENT_MOUSEUP_DISMISS = `mouseup.dismiss${EVENT_KEY$6}`;
  const EVENT_MOUSEDOWN_DISMISS = `mousedown.dismiss${EVENT_KEY$6}`;
  const EVENT_CLICK_DATA_API$2 = `click${EVENT_KEY$6}${DATA_API_KEY$3}`;
  const CLASS_NAME_OPEN = 'modal-open';
  const CLASS_NAME_FADE$3 = 'fade';
  const CLASS_NAME_SHOW$4 = 'show';
  const CLASS_NAME_STATIC = 'modal-static';
  const SELECTOR_DIALOG = '.modal-dialog';
  const SELECTOR_MODAL_BODY = '.modal-body';
  const SELECTOR_DATA_TOGGLE$2 = '[data-bs-toggle="modal"]';
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    focus: 'boolean',
    show: 'boolean'
  };
  var EVENT_HIDE$2 = "hide" + EVENT_KEY$5;
  var EVENT_HIDE_PREVENTED = "hidePrevented" + EVENT_KEY$5;
  var EVENT_HIDDEN$2 = "hidden" + EVENT_KEY$5;
  var EVENT_SHOW$2 = "show" + EVENT_KEY$5;
  var EVENT_SHOWN$2 = "shown" + EVENT_KEY$5;
  var EVENT_FOCUSIN = "focusin" + EVENT_KEY$5;
  var EVENT_RESIZE = "resize" + EVENT_KEY$5;
  var EVENT_CLICK_DISMISS = "click.dismiss" + EVENT_KEY$5;
  var EVENT_KEYDOWN_DISMISS = "keydown.dismiss" + EVENT_KEY$5;
  var EVENT_MOUSEUP_DISMISS = "mouseup.dismiss" + EVENT_KEY$5;
  var EVENT_MOUSEDOWN_DISMISS = "mousedown.dismiss" + EVENT_KEY$5;
  var EVENT_CLICK_DATA_API$5 = "click" + EVENT_KEY$5 + DATA_API_KEY$5;
  var CLASS_NAME_SCROLLABLE = 'modal-dialog-scrollable';
  var CLASS_NAME_SCROLLBAR_MEASURER = 'modal-scrollbar-measure';
  var CLASS_NAME_BACKDROP = 'modal-backdrop';
  var CLASS_NAME_OPEN = 'modal-open';
  var CLASS_NAME_FADE$1 = 'fade';
  var CLASS_NAME_SHOW$3 = 'show';
  var CLASS_NAME_STATIC = 'modal-static';
  var SELECTOR_DIALOG = '.modal-dialog';
  var SELECTOR_MODAL_BODY = '.modal-body';
  var SELECTOR_DATA_TOGGLE$3 = '[data-toggle="modal"]';
  var SELECTOR_DATA_DISMISS = '[data-dismiss="modal"]';
  var SELECTOR_FIXED_CONTENT = '.fixed-top, .fixed-bottom, .is-fixed, .sticky-top';
  var SELECTOR_STICKY_CONTENT = '.sticky-top';
<<<<<<< HEAD
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  /**
   * ------------------------------------------------------------------------
   * Class Definition
   * ------------------------------------------------------------------------
   */

<<<<<<< HEAD
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  class Modal extends BaseComponent {
    constructor(element, config) {
      super(element);
      this._config = this._getConfig(config);
      this._dialog = SelectorEngine.findOne(SELECTOR_DIALOG, this._element);
      this._backdrop = this._initializeBackDrop();
      this._focustrap = this._initializeFocusTrap();
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  var Modal = /*#__PURE__*/function () {
    function Modal(element, config) {
      this._config = this._getConfig(config);
      this._element = element;
      this._dialog = element.querySelector(SELECTOR_DIALOG);
      this._backdrop = null;
<<<<<<< HEAD
      this._isShown = false;
      this._isBodyOverflowing = false;
      this._ignoreBackdropClick = false;
      this._isTransitioning = false;
      this._scrollbarWidth = 0;
    } // Getters


    var _proto = Modal.prototype;

    // Public
    _proto.toggle = function toggle(relatedTarget) {
      return this._isShown ? this.hide() : this.show(relatedTarget);
    };

    _proto.show = function show(relatedTarget) {
      var _this = this;

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
      this._isShown = false;
      this._ignoreBackdropClick = false;
      this._isTransitioning = false;
      this._scrollBar = new ScrollBarHelper();
    } // Getters


    static get Default() {
      return Default$5;
    }

    static get NAME() {
      return NAME$6;
    } // Public


    toggle(relatedTarget) {
      return this._isShown ? this.hide() : this.show(relatedTarget);
    }

    show(relatedTarget) {
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      if (this._isShown || this._isTransitioning) {
        return;
      }

<<<<<<< HEAD
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      const showEvent = EventHandler.trigger(this._element, EVENT_SHOW$3, {
        relatedTarget
      });
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      if ($__default['default'](this._element).hasClass(CLASS_NAME_FADE$1)) {
        this._isTransitioning = true;
      }

      var showEvent = $__default['default'].Event(EVENT_SHOW$2, {
        relatedTarget: relatedTarget
      });
      $__default['default'](this._element).trigger(showEvent);
<<<<<<< HEAD

      if (this._isShown || showEvent.isDefaultPrevented()) {
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

      if (showEvent.defaultPrevented) {
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
        return;
      }

      this._isShown = true;

<<<<<<< HEAD
      this._checkScrollbar();

      this._setScrollbar();
=======
      if (this._isAnimated()) {
        this._isTransitioning = true;
      }

      this._scrollBar.hide();

      document.body.classList.add(CLASS_NAME_OPEN);
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277

      this._adjustDialog();

      this._setEscapeEvent();

      this._setResizeEvent();

<<<<<<< HEAD
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      EventHandler.on(this._dialog, EVENT_MOUSEDOWN_DISMISS, () => {
        EventHandler.one(this._element, EVENT_MOUSEUP_DISMISS, event => {
          if (event.target === this._element) {
            this._ignoreBackdropClick = true;
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      $__default['default'](this._element).on(EVENT_CLICK_DISMISS, SELECTOR_DATA_DISMISS, function (event) {
        return _this.hide(event);
      });
      $__default['default'](this._dialog).on(EVENT_MOUSEDOWN_DISMISS, function () {
        $__default['default'](_this._element).one(EVENT_MOUSEUP_DISMISS, function (event) {
          if ($__default['default'](event.target).is(_this._element)) {
            _this._ignoreBackdropClick = true;
<<<<<<< HEAD
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
          }
        });
      });

<<<<<<< HEAD
      this._showBackdrop(function () {
        return _this._showElement(relatedTarget);
      });
    };

    _proto.hide = function hide(event) {
      var _this2 = this;

      if (event) {
        event.preventDefault();
      }

=======
      this._showBackdrop(() => this._showElement(relatedTarget));
    }

    hide() {
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      if (!this._isShown || this._isTransitioning) {
        return;
      }

<<<<<<< HEAD
      var hideEvent = $__default['default'].Event(EVENT_HIDE$2);
      $__default['default'](this._element).trigger(hideEvent);

      if (!this._isShown || hideEvent.isDefaultPrevented()) {
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      const hideEvent = EventHandler.trigger(this._element, EVENT_HIDE$3);
========
      var hideEvent = $__default['default'].Event(EVENT_HIDE$2);
      $__default['default'](this._element).trigger(hideEvent);
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

      if (hideEvent.defaultPrevented) {
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
        return;
      }

      this._isShown = false;
<<<<<<< HEAD
      var transition = $__default['default'](this._element).hasClass(CLASS_NAME_FADE$1);

      if (transition) {
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
========
      var transition = $__default['default'](this._element).hasClass(CLASS_NAME_FADE$1);
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

      const isAnimated = this._isAnimated();

      if (isAnimated) {
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
        this._isTransitioning = true;
      }

      this._setEscapeEvent();

      this._setResizeEvent();

<<<<<<< HEAD
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      this._focustrap.deactivate();

      this._element.classList.remove(CLASS_NAME_SHOW$4);

      EventHandler.off(this._element, EVENT_CLICK_DISMISS);
      EventHandler.off(this._dialog, EVENT_MOUSEDOWN_DISMISS);

      this._queueCallback(() => this._hideModal(), this._element, isAnimated);
    }

    dispose() {
      [window, this._dialog].forEach(htmlElement => EventHandler.off(htmlElement, EVENT_KEY$6));

      this._backdrop.dispose();
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      $__default['default'](document).off(EVENT_FOCUSIN);
      $__default['default'](this._element).removeClass(CLASS_NAME_SHOW$3);
      $__default['default'](this._element).off(EVENT_CLICK_DISMISS);
      $__default['default'](this._dialog).off(EVENT_MOUSEDOWN_DISMISS);

      if (transition) {
        var transitionDuration = Util.getTransitionDurationFromElement(this._element);
        $__default['default'](this._element).one(Util.TRANSITION_END, function (event) {
          return _this2._hideModal(event);
        }).emulateTransitionEnd(transitionDuration);
      } else {
        this._hideModal();
      }
    };

    _proto.dispose = function dispose() {
      [window, this._element, this._dialog].forEach(function (htmlElement) {
        return $__default['default'](htmlElement).off(EVENT_KEY$5);
      });
      /**
       * `document` has 2 events `EVENT_FOCUSIN` and `EVENT_CLICK_DATA_API`
       * Do not move `document` in `htmlElements` array
       * It will remove `EVENT_CLICK_DATA_API` event that should remain
       */

      $__default['default'](document).off(EVENT_FOCUSIN);
      $__default['default'].removeData(this._element, DATA_KEY$5);
      this._config = null;
      this._element = null;
      this._dialog = null;
      this._backdrop = null;
      this._isShown = null;
      this._isBodyOverflowing = null;
      this._ignoreBackdropClick = null;
      this._isTransitioning = null;
      this._scrollbarWidth = null;
    };
<<<<<<< HEAD

    _proto.handleUpdate = function handleUpdate() {
      this._adjustDialog();
    } // Private
    ;

    _proto._getConfig = function _getConfig(config) {
      config = _extends({}, Default$3, config);
      Util.typeCheckConfig(NAME$5, config, DefaultType$3);
      return config;
    };

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

      this._focustrap.deactivate();

      super.dispose();
    }

    handleUpdate() {
      this._adjustDialog();
    } // Private

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js

    _initializeBackDrop() {
      return new Backdrop({
        isVisible: Boolean(this._config.backdrop),
        // 'static' option will be translated to true, and booleans will keep their value
        isAnimated: this._isAnimated()
      });
    }

    _initializeFocusTrap() {
      return new FocusTrap({
        trapElement: this._element
      });
    }

    _getConfig(config) {
      config = { ...Default$5,
        ...Manipulator.getDataAttributes(this._element),
        ...(typeof config === 'object' ? config : {})
      };
      typeCheckConfig(NAME$6, config, DefaultType$5);
========
    _proto._getConfig = function _getConfig(config) {
      config = _extends({}, Default$3, config);
      Util.typeCheckConfig(NAME$5, config, DefaultType$3);
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
      return config;
    }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    _showElement(relatedTarget) {
      const isAnimated = this._isAnimated();

      const modalBody = SelectorEngine.findOne(SELECTOR_MODAL_BODY, this._dialog);
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    _proto._triggerBackdropTransition = function _triggerBackdropTransition() {
      var _this3 = this;

      var hideEventPrevented = $__default['default'].Event(EVENT_HIDE_PREVENTED);
      $__default['default'](this._element).trigger(hideEventPrevented);

      if (hideEventPrevented.isDefaultPrevented()) {
        return;
      }

      var isModalOverflowing = this._element.scrollHeight > document.documentElement.clientHeight;

      if (!isModalOverflowing) {
        this._element.style.overflowY = 'hidden';
      }

      this._element.classList.add(CLASS_NAME_STATIC);

      var modalTransitionDuration = Util.getTransitionDurationFromElement(this._dialog);
      $__default['default'](this._element).off(Util.TRANSITION_END);
      $__default['default'](this._element).one(Util.TRANSITION_END, function () {
        _this3._element.classList.remove(CLASS_NAME_STATIC);

        if (!isModalOverflowing) {
          $__default['default'](_this3._element).one(Util.TRANSITION_END, function () {
            _this3._element.style.overflowY = '';
          }).emulateTransitionEnd(_this3._element, modalTransitionDuration);
        }
      }).emulateTransitionEnd(modalTransitionDuration);

      this._element.focus();
    };

    _proto._showElement = function _showElement(relatedTarget) {
      var _this4 = this;

      var transition = $__default['default'](this._element).hasClass(CLASS_NAME_FADE$1);
      var modalBody = this._dialog ? this._dialog.querySelector(SELECTOR_MODAL_BODY) : null;
<<<<<<< HEAD

      if (!this._element.parentNode || this._element.parentNode.nodeType !== Node.ELEMENT_NODE) {
        // Don't move modal's DOM position
        document.body.appendChild(this._element);
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

      if (!this._element.parentNode || this._element.parentNode.nodeType !== Node.ELEMENT_NODE) {
        // Don't move modal's DOM position
        document.body.append(this._element);
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      }

      this._element.style.display = 'block';

      this._element.removeAttribute('aria-hidden');

      this._element.setAttribute('aria-modal', true);

      this._element.setAttribute('role', 'dialog');
<<<<<<< HEAD
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277

      if ($__default['default'](this._dialog).hasClass(CLASS_NAME_SCROLLABLE) && modalBody) {
        modalBody.scrollTop = 0;
      } else {
        this._element.scrollTop = 0;
      }
<<<<<<< HEAD

      if (transition) {
        Util.reflow(this._element);
      }

      $__default['default'](this._element).addClass(CLASS_NAME_SHOW$3);

      if (this._config.focus) {
        this._enforceFocus();
      }

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

      this._element.scrollTop = 0;

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      if (modalBody) {
        modalBody.scrollTop = 0;
      }
========
      $__default['default'](this._element).addClass(CLASS_NAME_SHOW$3);
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

      if (isAnimated) {
        reflow(this._element);
      }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      this._element.classList.add(CLASS_NAME_SHOW$4);

      const transitionComplete = () => {
        if (this._config.focus) {
          this._focustrap.activate();
        }

        this._isTransitioning = false;
        EventHandler.trigger(this._element, EVENT_SHOWN$3, {
          relatedTarget
        });
      };

      this._queueCallback(transitionComplete, this._dialog, isAnimated);
    }

    _setEscapeEvent() {
      if (this._isShown) {
        EventHandler.on(this._element, EVENT_KEYDOWN_DISMISS$1, event => {
          if (this._config.keyboard && event.key === ESCAPE_KEY$1) {
            event.preventDefault();
            this.hide();
          } else if (!this._config.keyboard && event.key === ESCAPE_KEY$1) {
            this._triggerBackdropTransition();
          }
        });
      } else {
        EventHandler.off(this._element, EVENT_KEYDOWN_DISMISS$1);
      }
    }
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      var shownEvent = $__default['default'].Event(EVENT_SHOWN$2, {
        relatedTarget: relatedTarget
      });

      var transitionComplete = function transitionComplete() {
        if (_this4._config.focus) {
          _this4._element.focus();
        }

        _this4._isTransitioning = false;
        $__default['default'](_this4._element).trigger(shownEvent);
      };

      if (transition) {
        var transitionDuration = Util.getTransitionDurationFromElement(this._dialog);
        $__default['default'](this._dialog).one(Util.TRANSITION_END, transitionComplete).emulateTransitionEnd(transitionDuration);
      } else {
        transitionComplete();
      }
    };

    _proto._enforceFocus = function _enforceFocus() {
      var _this5 = this;

      $__default['default'](document).off(EVENT_FOCUSIN) // Guard against infinite focus loop
      .on(EVENT_FOCUSIN, function (event) {
        if (document !== event.target && _this5._element !== event.target && $__default['default'](_this5._element).has(event.target).length === 0) {
          _this5._element.focus();
        }
      });
    };

    _proto._setEscapeEvent = function _setEscapeEvent() {
      var _this6 = this;

      if (this._isShown) {
        $__default['default'](this._element).on(EVENT_KEYDOWN_DISMISS, function (event) {
          if (_this6._config.keyboard && event.which === ESCAPE_KEYCODE$1) {
            event.preventDefault();

            _this6.hide();
          } else if (!_this6._config.keyboard && event.which === ESCAPE_KEYCODE$1) {
            _this6._triggerBackdropTransition();
          }
        });
      } else if (!this._isShown) {
        $__default['default'](this._element).off(EVENT_KEYDOWN_DISMISS);
      }
    };

    _proto._setResizeEvent = function _setResizeEvent() {
      var _this7 = this;
<<<<<<< HEAD

      if (this._isShown) {
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

    _setResizeEvent() {
      if (this._isShown) {
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
        EventHandler.on(window, EVENT_RESIZE, () => this._adjustDialog());
      } else {
        EventHandler.off(window, EVENT_RESIZE);
      }
    }
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
        $__default['default'](window).on(EVENT_RESIZE, function (event) {
          return _this7.handleUpdate(event);
        });
      } else {
        $__default['default'](window).off(EVENT_RESIZE);
      }
    };

    _proto._hideModal = function _hideModal() {
      var _this8 = this;
<<<<<<< HEAD

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

    _hideModal() {
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      this._element.style.display = 'none';

      this._element.setAttribute('aria-hidden', true);

      this._element.removeAttribute('aria-modal');

      this._element.removeAttribute('role');

      this._isTransitioning = false;

<<<<<<< HEAD
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      this._backdrop.hide(() => {
        document.body.classList.remove(CLASS_NAME_OPEN);

        this._resetAdjustments();

        this._scrollBar.reset();

        EventHandler.trigger(this._element, EVENT_HIDDEN$3);
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      this._showBackdrop(function () {
        $__default['default'](document.body).removeClass(CLASS_NAME_OPEN);

        _this8._resetAdjustments();

        _this8._resetScrollbar();

        $__default['default'](_this8._element).trigger(EVENT_HIDDEN$2);
<<<<<<< HEAD
      });
    };

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
      });
    }

    _showBackdrop(callback) {
      EventHandler.on(this._element, EVENT_CLICK_DISMISS, event => {
        if (this._ignoreBackdropClick) {
          this._ignoreBackdropClick = false;
          return;
        }

        if (event.target !== event.currentTarget) {
          return;
        }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
        if (this._config.backdrop === true) {
          this.hide();
        } else if (this._config.backdrop === 'static') {
          this._triggerBackdropTransition();
        }
      });

      this._backdrop.show(callback);
    }

    _isAnimated() {
      return this._element.classList.contains(CLASS_NAME_FADE$3);
    }

    _triggerBackdropTransition() {
      const hideEvent = EventHandler.trigger(this._element, EVENT_HIDE_PREVENTED);

      if (hideEvent.defaultPrevented) {
        return;
      }

      const {
        classList,
        scrollHeight,
        style
      } = this._element;
      const isModalOverflowing = scrollHeight > document.documentElement.clientHeight; // return if the following background transition hasn't yet completed

      if (!isModalOverflowing && style.overflowY === 'hidden' || classList.contains(CLASS_NAME_STATIC)) {
        return;
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    _proto._removeBackdrop = function _removeBackdrop() {
      if (this._backdrop) {
        $__default['default'](this._backdrop).remove();
        this._backdrop = null;
<<<<<<< HEAD
      }
    };

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
      }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      if (!isModalOverflowing) {
        style.overflowY = 'hidden';
      }

      classList.add(CLASS_NAME_STATIC);

      this._queueCallback(() => {
        classList.remove(CLASS_NAME_STATIC);
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    _proto._showBackdrop = function _showBackdrop(callback) {
      var _this9 = this;

      var animate = $__default['default'](this._element).hasClass(CLASS_NAME_FADE$1) ? CLASS_NAME_FADE$1 : '';

      if (this._isShown && this._config.backdrop) {
        this._backdrop = document.createElement('div');
        this._backdrop.className = CLASS_NAME_BACKDROP;
<<<<<<< HEAD

        if (animate) {
          this._backdrop.classList.add(animate);
        }

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

        if (!isModalOverflowing) {
          this._queueCallback(() => {
            style.overflowY = '';
          }, this._dialog);
        }
      }, this._dialog);

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      this._element.focus();
    } // ----------------------------------------------------------------------
    // the following methods are used to handle overflowing modals
    // ----------------------------------------------------------------------
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
        $__default['default'](this._backdrop).appendTo(document.body);
        $__default['default'](this._element).on(EVENT_CLICK_DISMISS, function (event) {
          if (_this9._ignoreBackdropClick) {
            _this9._ignoreBackdropClick = false;
            return;
          }
<<<<<<< HEAD

          if (event.target !== event.currentTarget) {
            return;
          }

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js


<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    _adjustDialog() {
      const isModalOverflowing = this._element.scrollHeight > document.documentElement.clientHeight;
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
          if (_this9._config.backdrop === 'static') {
            _this9._triggerBackdropTransition();
          } else {
            _this9.hide();
          }
        });
<<<<<<< HEAD

        if (animate) {
          Util.reflow(this._backdrop);
        }

        $__default['default'](this._backdrop).addClass(CLASS_NAME_SHOW$3);

        if (!callback) {
          return;
        }

        if (!animate) {
          callback();
          return;
        }

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

      const scrollbarWidth = this._scrollBar.getWidth();

      const isBodyOverflowing = scrollbarWidth > 0;

      if (!isBodyOverflowing && isModalOverflowing && !isRTL() || isBodyOverflowing && !isModalOverflowing && isRTL()) {
        this._element.style.paddingLeft = `${scrollbarWidth}px`;
      }

      if (isBodyOverflowing && !isModalOverflowing && !isRTL() || !isBodyOverflowing && isModalOverflowing && isRTL()) {
        this._element.style.paddingRight = `${scrollbarWidth}px`;
      }
    }

    _resetAdjustments() {
      this._element.style.paddingLeft = '';
      this._element.style.paddingRight = '';
    } // Static

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
========
        $__default['default'](this._backdrop).addClass(CLASS_NAME_SHOW$3);
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

    static jQueryInterface(config, relatedTarget) {
      return this.each(function () {
        const data = Modal.getOrCreateInstance(this, config);

        if (typeof config !== 'string') {
          return;
        }

        if (typeof data[config] === 'undefined') {
          throw new TypeError(`No method named "${config}"`);
        }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
        data[config](relatedTarget);
      });
    }

  }
  /**
   * ------------------------------------------------------------------------
   * Data Api implementation
   * ------------------------------------------------------------------------
   */
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
        var backdropTransitionDuration = Util.getTransitionDurationFromElement(this._backdrop);
        $__default['default'](this._backdrop).one(Util.TRANSITION_END, callback).emulateTransitionEnd(backdropTransitionDuration);
      } else if (!this._isShown && this._backdrop) {
        $__default['default'](this._backdrop).removeClass(CLASS_NAME_SHOW$3);

        var callbackRemove = function callbackRemove() {
          _this9._removeBackdrop();
<<<<<<< HEAD

          if (callback) {
            callback();
          }
        };

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js


<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  EventHandler.on(document, EVENT_CLICK_DATA_API$2, SELECTOR_DATA_TOGGLE$2, function (event) {
    const target = getElementFromSelector(this);

    if (['A', 'AREA'].includes(this.tagName)) {
      event.preventDefault();
    }

    EventHandler.one(target, EVENT_SHOW$3, showEvent => {
      if (showEvent.defaultPrevented) {
        // only register focus restorer if modal will actually get shown
        return;
      }

      EventHandler.one(target, EVENT_HIDDEN$3, () => {
        if (isVisible(this)) {
          this.focus();
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
        if ($__default['default'](this._element).hasClass(CLASS_NAME_FADE$1)) {
          var _backdropTransitionDuration = Util.getTransitionDurationFromElement(this._backdrop);

          $__default['default'](this._backdrop).one(Util.TRANSITION_END, callbackRemove).emulateTransitionEnd(_backdropTransitionDuration);
        } else {
          callbackRemove();
<<<<<<< HEAD
        }
      } else if (callback) {
        callback();
      }
    } // ----------------------------------------------------------------------
    // the following methods are used to handle overflowing modals
    // todo (fat): these should probably be refactored out of modal.js
    // ----------------------------------------------------------------------
    ;

    _proto._adjustDialog = function _adjustDialog() {
      var isModalOverflowing = this._element.scrollHeight > document.documentElement.clientHeight;

      if (!this._isBodyOverflowing && isModalOverflowing) {
        this._element.style.paddingLeft = this._scrollbarWidth + "px";
      }

      if (this._isBodyOverflowing && !isModalOverflowing) {
        this._element.style.paddingRight = this._scrollbarWidth + "px";
      }
    };

    _proto._resetAdjustments = function _resetAdjustments() {
      this._element.style.paddingLeft = '';
      this._element.style.paddingRight = '';
    };

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
        }
      });
    });
    const data = Modal.getOrCreateInstance(target);
    data.toggle(this);
  });
  enableDismissTrigger(Modal);
  /**
   * ------------------------------------------------------------------------
   * jQuery
   * ------------------------------------------------------------------------
   * add .Modal to jQuery only if jQuery is present
   */

  defineJQueryPlugin(Modal);

  /**
   * --------------------------------------------------------------------------
   * Bootstrap (v5.1.0): offcanvas.js
   * Licensed under MIT (https://github.com/twbs/bootstrap/blob/master/LICENSE)
   * --------------------------------------------------------------------------
   */
  /**
   * ------------------------------------------------------------------------
   * Constants
   * ------------------------------------------------------------------------
   */

  const NAME$5 = 'offcanvas';
  const DATA_KEY$5 = 'bs.offcanvas';
  const EVENT_KEY$5 = `.${DATA_KEY$5}`;
  const DATA_API_KEY$2 = '.data-api';
  const EVENT_LOAD_DATA_API$1 = `load${EVENT_KEY$5}${DATA_API_KEY$2}`;
  const ESCAPE_KEY = 'Escape';
  const Default$4 = {
    backdrop: true,
    keyboard: true,
    scroll: false
  };
  const DefaultType$4 = {
    backdrop: 'boolean',
    keyboard: 'boolean',
    scroll: 'boolean'
  };
  const CLASS_NAME_SHOW$3 = 'show';
  const CLASS_NAME_BACKDROP = 'offcanvas-backdrop';
  const OPEN_SELECTOR = '.offcanvas.show';
  const EVENT_SHOW$2 = `show${EVENT_KEY$5}`;
  const EVENT_SHOWN$2 = `shown${EVENT_KEY$5}`;
  const EVENT_HIDE$2 = `hide${EVENT_KEY$5}`;
  const EVENT_HIDDEN$2 = `hidden${EVENT_KEY$5}`;
  const EVENT_CLICK_DATA_API$1 = `click${EVENT_KEY$5}${DATA_API_KEY$2}`;
  const EVENT_KEYDOWN_DISMISS = `keydown.dismiss${EVENT_KEY$5}`;
  const SELECTOR_DATA_TOGGLE$1 = '[data-bs-toggle="offcanvas"]';
  /**
   * ------------------------------------------------------------------------
   * Class Definition
   * ------------------------------------------------------------------------
   */

  class Offcanvas extends BaseComponent {
    constructor(element, config) {
      super(element);
      this._config = this._getConfig(config);
      this._isShown = false;
      this._backdrop = this._initializeBackDrop();
      this._focustrap = this._initializeFocusTrap();

      this._addEventListeners();
    } // Getters


    static get NAME() {
      return NAME$5;
    }

    static get Default() {
      return Default$4;
    } // Public


    toggle(relatedTarget) {
      return this._isShown ? this.hide() : this.show(relatedTarget);
    }

    show(relatedTarget) {
      if (this._isShown) {
        return;
      }

      const showEvent = EventHandler.trigger(this._element, EVENT_SHOW$2, {
        relatedTarget
      });

      if (showEvent.defaultPrevented) {
        return;
      }

      this._isShown = true;
      this._element.style.visibility = 'visible';

      this._backdrop.show();

      if (!this._config.scroll) {
        new ScrollBarHelper().hide();
      }

      this._element.removeAttribute('aria-hidden');

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      this._element.setAttribute('aria-modal', true);

      this._element.setAttribute('role', 'dialog');

      this._element.classList.add(CLASS_NAME_SHOW$3);

      const completeCallBack = () => {
        if (!this._config.scroll) {
          this._focustrap.activate();
        }

        EventHandler.trigger(this._element, EVENT_SHOWN$2, {
          relatedTarget
        });
      };

      this._queueCallback(completeCallBack, this._element, true);
    }

    hide() {
      if (!this._isShown) {
        return;
      }

      const hideEvent = EventHandler.trigger(this._element, EVENT_HIDE$2);

      if (hideEvent.defaultPrevented) {
        return;
      }

      this._focustrap.deactivate();

      this._element.blur();

      this._isShown = false;

      this._element.classList.remove(CLASS_NAME_SHOW$3);

      this._backdrop.hide();

      const completeCallback = () => {
        this._element.setAttribute('aria-hidden', true);

        this._element.removeAttribute('aria-modal');

        this._element.removeAttribute('role');

        this._element.style.visibility = 'hidden';

        if (!this._config.scroll) {
          new ScrollBarHelper().reset();
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    _proto._checkScrollbar = function _checkScrollbar() {
      var rect = document.body.getBoundingClientRect();
      this._isBodyOverflowing = Math.round(rect.left + rect.right) < window.innerWidth;
      this._scrollbarWidth = this._getScrollbarWidth();
    };

    _proto._setScrollbar = function _setScrollbar() {
      var _this10 = this;

      if (this._isBodyOverflowing) {
        // Note: DOMNode.style.paddingRight returns the actual value or '' if not set
        //   while $(DOMNode).css('padding-right') returns the calculated value or 0 if not set
        var fixedContent = [].slice.call(document.querySelectorAll(SELECTOR_FIXED_CONTENT));
        var stickyContent = [].slice.call(document.querySelectorAll(SELECTOR_STICKY_CONTENT)); // Adjust fixed content padding

        $__default['default'](fixedContent).each(function (index, element) {
          var actualPadding = element.style.paddingRight;
          var calculatedPadding = $__default['default'](element).css('padding-right');
          $__default['default'](element).data('padding-right', actualPadding).css('padding-right', parseFloat(calculatedPadding) + _this10._scrollbarWidth + "px");
        }); // Adjust sticky content margin

        $__default['default'](stickyContent).each(function (index, element) {
          var actualMargin = element.style.marginRight;
          var calculatedMargin = $__default['default'](element).css('margin-right');
          $__default['default'](element).data('margin-right', actualMargin).css('margin-right', parseFloat(calculatedMargin) - _this10._scrollbarWidth + "px");
        }); // Adjust body padding

        var actualPadding = document.body.style.paddingRight;
        var calculatedPadding = $__default['default'](document.body).css('padding-right');
        $__default['default'](document.body).data('padding-right', actualPadding).css('padding-right', parseFloat(calculatedPadding) + this._scrollbarWidth + "px");
      }

      $__default['default'](document.body).addClass(CLASS_NAME_OPEN);
    };

    _proto._resetScrollbar = function _resetScrollbar() {
      // Restore fixed content padding
      var fixedContent = [].slice.call(document.querySelectorAll(SELECTOR_FIXED_CONTENT));
      $__default['default'](fixedContent).each(function (index, element) {
        var padding = $__default['default'](element).data('padding-right');
        $__default['default'](element).removeData('padding-right');
        element.style.paddingRight = padding ? padding : '';
      }); // Restore sticky content

      var elements = [].slice.call(document.querySelectorAll("" + SELECTOR_STICKY_CONTENT));
      $__default['default'](elements).each(function (index, element) {
        var margin = $__default['default'](element).data('margin-right');

        if (typeof margin !== 'undefined') {
          $__default['default'](element).css('margin-right', margin).removeData('margin-right');
        }
      }); // Restore body padding

      var padding = $__default['default'](document.body).data('padding-right');
      $__default['default'](document.body).removeData('padding-right');
      document.body.style.paddingRight = padding ? padding : '';
    };

    _proto._getScrollbarWidth = function _getScrollbarWidth() {
      // thx d.walsh
      var scrollDiv = document.createElement('div');
      scrollDiv.className = CLASS_NAME_SCROLLBAR_MEASURER;
      document.body.appendChild(scrollDiv);
      var scrollbarWidth = scrollDiv.getBoundingClientRect().width - scrollDiv.clientWidth;
      document.body.removeChild(scrollDiv);
      return scrollbarWidth;
    } // Static
    ;

    Modal._jQueryInterface = function _jQueryInterface(config, relatedTarget) {
      return this.each(function () {
        var data = $__default['default'](this).data(DATA_KEY$5);

        var _config = _extends({}, Default$3, $__default['default'](this).data(), typeof config === 'object' && config ? config : {});

        if (!data) {
          data = new Modal(this, _config);
          $__default['default'](this).data(DATA_KEY$5, data);
<<<<<<< HEAD
        }

        if (typeof config === 'string') {
          if (typeof data[config] === 'undefined') {
            throw new TypeError("No method named \"" + config + "\"");
          }

          data[config](relatedTarget);
        } else if (_config.show) {
          data.show(relatedTarget);
        }
      });
    };

    _createClass(Modal, null, [{
      key: "VERSION",
      get: function get() {
        return VERSION$5;
      }
    }, {
      key: "Default",
      get: function get() {
        return Default$3;
      }
    }]);

    return Modal;
  }();
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
        }

        EventHandler.trigger(this._element, EVENT_HIDDEN$2);
      };

      this._queueCallback(completeCallback, this._element, true);
    }

    dispose() {
      this._backdrop.dispose();

      this._focustrap.deactivate();

      super.dispose();
    } // Private


    _getConfig(config) {
      config = { ...Default$4,
        ...Manipulator.getDataAttributes(this._element),
        ...(typeof config === 'object' ? config : {})
      };
      typeCheckConfig(NAME$5, config, DefaultType$4);
      return config;
    }

    _initializeBackDrop() {
      return new Backdrop({
        className: CLASS_NAME_BACKDROP,
        isVisible: this._config.backdrop,
        isAnimated: true,
        rootElement: this._element.parentNode,
        clickCallback: () => this.hide()
      });
    }

    _initializeFocusTrap() {
      return new FocusTrap({
        trapElement: this._element
      });
    }

    _addEventListeners() {
      EventHandler.on(this._element, EVENT_KEYDOWN_DISMISS, event => {
        if (this._config.keyboard && event.key === ESCAPE_KEY) {
          this.hide();
        }
      });
    } // Static


    static jQueryInterface(config) {
      return this.each(function () {
        const data = Offcanvas.getOrCreateInstance(this, config);

        if (typeof config !== 'string') {
          return;
        }

        if (data[config] === undefined || config.startsWith('_') || config === 'constructor') {
          throw new TypeError(`No method named "${config}"`);
        }

        data[config](this);
      });
    }

  }
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  /**
   * ------------------------------------------------------------------------
   * Data Api implementation
   * ------------------------------------------------------------------------
   */


<<<<<<< HEAD
  $__default['default'](document).on(EVENT_CLICK_DATA_API$5, SELECTOR_DATA_TOGGLE$3, function (event) {
    var _this11 = this;

    var target;
    var selector = Util.getSelectorFromElement(this);

    if (selector) {
      target = document.querySelector(selector);
    }

=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  EventHandler.on(document, EVENT_CLICK_DATA_API$1, SELECTOR_DATA_TOGGLE$1, function (event) {
    const target = getElementFromSelector(this);
========
  $__default['default'](document).on(EVENT_CLICK_DATA_API$5, SELECTOR_DATA_TOGGLE$3, function (event) {
    var _this11 = this;
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

    if (['A', 'AREA'].includes(this.tagName)) {
      event.preventDefault();
    }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    if (isDisabled(this)) {
      return;
    }

    EventHandler.one(target, EVENT_HIDDEN$2, () => {
      // focus on trigger when it is closed
      if (isVisible(this)) {
        this.focus();
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    var config = $__default['default'](target).data(DATA_KEY$5) ? 'toggle' : _extends({}, $__default['default'](target).data(), $__default['default'](this).data());

    if (this.tagName === 'A' || this.tagName === 'AREA') {
      event.preventDefault();
    }

    var $target = $__default['default'](target).one(EVENT_SHOW$2, function (showEvent) {
      if (showEvent.isDefaultPrevented()) {
        // Only register focus restorer if modal will actually get shown
        return;
<<<<<<< HEAD
      }

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
      }
    }); // avoid conflict when clicking a toggler of an offcanvas, while another is open

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    const allReadyOpen = SelectorEngine.findOne(OPEN_SELECTOR);

    if (allReadyOpen && allReadyOpen !== target) {
      Offcanvas.getInstance(allReadyOpen).hide();
    }

    const data = Offcanvas.getOrCreateInstance(target);
    data.toggle(this);
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      $target.one(EVENT_HIDDEN$2, function () {
        if ($__default['default'](_this11).is(':visible')) {
          _this11.focus();
        }
      });
    });

    Modal._jQueryInterface.call($__default['default'](target), config, this);
<<<<<<< HEAD
  });
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
  });
  EventHandler.on(window, EVENT_LOAD_DATA_API$1, () => SelectorEngine.find(OPEN_SELECTOR).forEach(el => Offcanvas.getOrCreateInstance(el).show()));
  enableDismissTrigger(Offcanvas);
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  /**
   * ------------------------------------------------------------------------
   * jQuery
   * ------------------------------------------------------------------------
   */

<<<<<<< HEAD
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  defineJQueryPlugin(Offcanvas);

  /**
   * --------------------------------------------------------------------------
   * Bootstrap (v5.1.0): util/sanitizer.js
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  $__default['default'].fn[NAME$5] = Modal._jQueryInterface;
  $__default['default'].fn[NAME$5].Constructor = Modal;

  $__default['default'].fn[NAME$5].noConflict = function () {
    $__default['default'].fn[NAME$5] = JQUERY_NO_CONFLICT$5;
    return Modal._jQueryInterface;
  };

  /**
   * --------------------------------------------------------------------------
   * Bootstrap (v4.6.0): tools/sanitizer.js
<<<<<<< HEAD
   * Licensed under MIT (https://github.com/twbs/bootstrap/blob/main/LICENSE)
   * --------------------------------------------------------------------------
   */
  var uriAttrs = ['background', 'cite', 'href', 'itemtype', 'longdesc', 'poster', 'src', 'xlink:href'];
  var ARIA_ATTRIBUTE_PATTERN = /^aria-[\w-]*$/i;
  var DefaultWhitelist = {
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
   * Licensed under MIT (https://github.com/twbs/bootstrap/blob/main/LICENSE)
   * --------------------------------------------------------------------------
   */
  const uriAttrs = new Set(['background', 'cite', 'href', 'itemtype', 'longdesc', 'poster', 'src', 'xlink:href']);
  const ARIA_ATTRIBUTE_PATTERN = /^aria-[\w-]*$/i;
  /**
   * A pattern that recognizes a commonly useful subset of URLs that are safe.
   *
   * Shoutout to Angular 7 https://github.com/angular/angular/blob/7.2.4/packages/core/src/sanitization/url_sanitizer.ts
   */

  const SAFE_URL_PATTERN = /^(?:(?:https?|mailto|ftp|tel|file):|[^#&/:?]*(?:[#/?]|$))/i;
  /**
   * A pattern that matches safe data URLs. Only matches image, video and audio types.
   *
   * Shoutout to Angular 7 https://github.com/angular/angular/blob/7.2.4/packages/core/src/sanitization/url_sanitizer.ts
   */

  const DATA_URL_PATTERN = /^data:(?:image\/(?:bmp|gif|jpeg|jpg|png|tiff|webp)|video\/(?:mpeg|mp4|ogg|webm)|audio\/(?:mp3|oga|ogg|opus));base64,[\d+/a-z]+=*$/i;

  const allowedAttribute = (attr, allowedAttributeList) => {
    const attrName = attr.nodeName.toLowerCase();

    if (allowedAttributeList.includes(attrName)) {
      if (uriAttrs.has(attrName)) {
        return Boolean(SAFE_URL_PATTERN.test(attr.nodeValue) || DATA_URL_PATTERN.test(attr.nodeValue));
      }

      return true;
    }

    const regExp = allowedAttributeList.filter(attrRegex => attrRegex instanceof RegExp); // Check if a regular expression validates the attribute.

    for (let i = 0, len = regExp.length; i < len; i++) {
      if (regExp[i].test(attrName)) {
        return true;
      }
    }

    return false;
  };

  const DefaultAllowlist = {
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    // Global attributes allowed on any supplied element below.
    '*': ['class', 'dir', 'id', 'lang', 'role', ARIA_ATTRIBUTE_PATTERN],
    a: ['target', 'href', 'title', 'rel'],
    area: [],
    b: [],
    br: [],
    col: [],
    code: [],
    div: [],
    em: [],
    hr: [],
    h1: [],
    h2: [],
    h3: [],
    h4: [],
    h5: [],
    h6: [],
    i: [],
    img: ['src', 'srcset', 'alt', 'title', 'width', 'height'],
    li: [],
    ol: [],
    p: [],
    pre: [],
    s: [],
    small: [],
    span: [],
    sub: [],
    sup: [],
    strong: [],
    u: [],
    ul: []
  };
<<<<<<< HEAD
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  function sanitizeHtml(unsafeHtml, allowList, sanitizeFn) {
    if (!unsafeHtml.length) {
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  /**
   * A pattern that recognizes a commonly useful subset of URLs that are safe.
   *
   * Shoutout to Angular 7 https://github.com/angular/angular/blob/7.2.4/packages/core/src/sanitization/url_sanitizer.ts
   */

  var SAFE_URL_PATTERN = /^(?:(?:https?|mailto|ftp|tel|file):|[^#&/:?]*(?:[#/?]|$))/gi;
  /**
   * A pattern that matches safe data URLs. Only matches image, video and audio types.
   *
   * Shoutout to Angular 7 https://github.com/angular/angular/blob/7.2.4/packages/core/src/sanitization/url_sanitizer.ts
   */

  var DATA_URL_PATTERN = /^data:(?:image\/(?:bmp|gif|jpeg|jpg|png|tiff|webp)|video\/(?:mpeg|mp4|ogg|webm)|audio\/(?:mp3|oga|ogg|opus));base64,[\d+/a-z]+=*$/i;

  function allowedAttribute(attr, allowedAttributeList) {
    var attrName = attr.nodeName.toLowerCase();

    if (allowedAttributeList.indexOf(attrName) !== -1) {
      if (uriAttrs.indexOf(attrName) !== -1) {
        return Boolean(attr.nodeValue.match(SAFE_URL_PATTERN) || attr.nodeValue.match(DATA_URL_PATTERN));
      }

      return true;
    }

    var regExp = allowedAttributeList.filter(function (attrRegex) {
      return attrRegex instanceof RegExp;
    }); // Check if a regular expression validates the attribute.

    for (var i = 0, len = regExp.length; i < len; i++) {
      if (attrName.match(regExp[i])) {
        return true;
      }
    }

    return false;
  }

  function sanitizeHtml(unsafeHtml, whiteList, sanitizeFn) {
    if (unsafeHtml.length === 0) {
<<<<<<< HEAD
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      return unsafeHtml;
    }

    if (sanitizeFn && typeof sanitizeFn === 'function') {
      return sanitizeFn(unsafeHtml);
    }

<<<<<<< HEAD
    var domParser = new window.DOMParser();
    var createdDocument = domParser.parseFromString(unsafeHtml, 'text/html');
    var whitelistKeys = Object.keys(whiteList);
    var elements = [].slice.call(createdDocument.body.querySelectorAll('*'));

    var _loop = function _loop(i, len) {
      var el = elements[i];
      var elName = el.nodeName.toLowerCase();

      if (whitelistKeys.indexOf(el.nodeName.toLowerCase()) === -1) {
        el.parentNode.removeChild(el);
        return "continue";
      }

      var attributeList = [].slice.call(el.attributes);
      var whitelistedAttributes = [].concat(whiteList['*'] || [], whiteList[elName] || []);
      attributeList.forEach(function (attr) {
        if (!allowedAttribute(attr, whitelistedAttributes)) {
          el.removeAttribute(attr.nodeName);
        }
      });
=======
    const domParser = new window.DOMParser();
    const createdDocument = domParser.parseFromString(unsafeHtml, 'text/html');
    const allowlistKeys = Object.keys(allowList);
    const elements = [].concat(...createdDocument.body.querySelectorAll('*'));

    for (let i = 0, len = elements.length; i < len; i++) {
      const el = elements[i];
      const elName = el.nodeName.toLowerCase();

      if (!allowlistKeys.includes(elName)) {
        el.remove();
        continue;
      }

      const attributeList = [].concat(...el.attributes);
      const allowedAttributes = [].concat(allowList['*'] || [], allowList[elName] || []);
      attributeList.forEach(attr => {
        if (!allowedAttribute(attr, allowedAttributes)) {
          el.removeAttribute(attr.nodeName);
        }
      });
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    };

    for (var i = 0, len = elements.length; i < len; i++) {
      var _ret = _loop(i);

      if (_ret === "continue") continue;
<<<<<<< HEAD
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    }

    return createdDocument.body.innerHTML;
  }

  /**
<<<<<<< HEAD
=======
   * --------------------------------------------------------------------------
   * Bootstrap (v5.1.0): tooltip.js
   * Licensed under MIT (https://github.com/twbs/bootstrap/blob/main/LICENSE)
   * --------------------------------------------------------------------------
   */
  /**
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
   * ------------------------------------------------------------------------
   * Constants
   * ------------------------------------------------------------------------
   */

<<<<<<< HEAD
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  const NAME$4 = 'tooltip';
  const DATA_KEY$4 = 'bs.tooltip';
  const EVENT_KEY$4 = `.${DATA_KEY$4}`;
  const CLASS_PREFIX$1 = 'bs-tooltip';
  const DISALLOWED_ATTRIBUTES = new Set(['sanitize', 'allowList', 'sanitizeFn']);
  const DefaultType$3 = {
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  var NAME$6 = 'tooltip';
  var VERSION$6 = '4.6.0';
  var DATA_KEY$6 = 'bs.tooltip';
  var EVENT_KEY$6 = "." + DATA_KEY$6;
  var JQUERY_NO_CONFLICT$6 = $__default['default'].fn[NAME$6];
  var CLASS_PREFIX = 'bs-tooltip';
  var BSCLS_PREFIX_REGEX = new RegExp("(^|\\s)" + CLASS_PREFIX + "\\S+", 'g');
  var DISALLOWED_ATTRIBUTES = ['sanitize', 'whiteList', 'sanitizeFn'];
  var DefaultType$4 = {
<<<<<<< HEAD
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    animation: 'boolean',
    template: 'string',
    title: '(string|element|function)',
    trigger: 'string',
    delay: '(number|object)',
    html: 'boolean',
    selector: '(string|boolean)',
    placement: '(string|function)',
<<<<<<< HEAD
    offset: '(number|string|function)',
    container: '(string|element|boolean)',
    fallbackPlacement: '(string|array)',
=======
    offset: '(array|string|function)',
    container: '(string|element|boolean)',
    fallbackPlacements: 'array',
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    boundary: '(string|element)',
    customClass: '(string|function)',
    sanitize: 'boolean',
    sanitizeFn: '(null|function)',
<<<<<<< HEAD
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    allowList: 'object',
    popperConfig: '(null|object|function)'
  };
  const AttachmentMap = {
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    whiteList: 'object',
    popperConfig: '(null|object)'
  };
  var AttachmentMap = {
<<<<<<< HEAD
    AUTO: 'auto',
    TOP: 'top',
    RIGHT: 'right',
    BOTTOM: 'bottom',
    LEFT: 'left'
  };
  var Default$4 = {
    animation: true,
    template: '<div class="tooltip" role="tooltip">' + '<div class="arrow"></div>' + '<div class="tooltip-inner"></div></div>',
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
    AUTO: 'auto',
    TOP: 'top',
    RIGHT: isRTL() ? 'left' : 'right',
    BOTTOM: 'bottom',
    LEFT: isRTL() ? 'right' : 'left'
  };
  const Default$3 = {
    animation: true,
    template: '<div class="tooltip" role="tooltip">' + '<div class="tooltip-arrow"></div>' + '<div class="tooltip-inner"></div>' + '</div>',
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    trigger: 'hover focus',
    title: '',
    delay: 0,
    html: false,
    selector: false,
    placement: 'top',
<<<<<<< HEAD
    offset: 0,
    container: false,
=======
    offset: [0, 0],
    container: false,
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    fallbackPlacements: ['top', 'right', 'bottom', 'left'],
    boundary: 'clippingParents',
    customClass: '',
    sanitize: true,
    sanitizeFn: null,
    allowList: DefaultAllowlist,
    popperConfig: null
  };
  const Event$2 = {
    HIDE: `hide${EVENT_KEY$4}`,
    HIDDEN: `hidden${EVENT_KEY$4}`,
    SHOW: `show${EVENT_KEY$4}`,
    SHOWN: `shown${EVENT_KEY$4}`,
    INSERTED: `inserted${EVENT_KEY$4}`,
    CLICK: `click${EVENT_KEY$4}`,
    FOCUSIN: `focusin${EVENT_KEY$4}`,
    FOCUSOUT: `focusout${EVENT_KEY$4}`,
    MOUSEENTER: `mouseenter${EVENT_KEY$4}`,
    MOUSELEAVE: `mouseleave${EVENT_KEY$4}`
  };
  const CLASS_NAME_FADE$2 = 'fade';
  const CLASS_NAME_MODAL = 'modal';
  const CLASS_NAME_SHOW$2 = 'show';
  const HOVER_STATE_SHOW = 'show';
  const HOVER_STATE_OUT = 'out';
  const SELECTOR_TOOLTIP_INNER = '.tooltip-inner';
  const SELECTOR_MODAL = `.${CLASS_NAME_MODAL}`;
  const EVENT_MODAL_HIDE = 'hide.bs.modal';
  const TRIGGER_HOVER = 'hover';
  const TRIGGER_FOCUS = 'focus';
  const TRIGGER_CLICK = 'click';
  const TRIGGER_MANUAL = 'manual';
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    fallbackPlacement: 'flip',
    boundary: 'scrollParent',
    customClass: '',
    sanitize: true,
    sanitizeFn: null,
    whiteList: DefaultWhitelist,
    popperConfig: null
  };
  var HOVER_STATE_SHOW = 'show';
  var HOVER_STATE_OUT = 'out';
  var Event = {
    HIDE: "hide" + EVENT_KEY$6,
    HIDDEN: "hidden" + EVENT_KEY$6,
    SHOW: "show" + EVENT_KEY$6,
    SHOWN: "shown" + EVENT_KEY$6,
    INSERTED: "inserted" + EVENT_KEY$6,
    CLICK: "click" + EVENT_KEY$6,
    FOCUSIN: "focusin" + EVENT_KEY$6,
    FOCUSOUT: "focusout" + EVENT_KEY$6,
    MOUSEENTER: "mouseenter" + EVENT_KEY$6,
    MOUSELEAVE: "mouseleave" + EVENT_KEY$6
  };
  var CLASS_NAME_FADE$2 = 'fade';
  var CLASS_NAME_SHOW$4 = 'show';
  var SELECTOR_TOOLTIP_INNER = '.tooltip-inner';
  var SELECTOR_ARROW = '.arrow';
  var TRIGGER_HOVER = 'hover';
  var TRIGGER_FOCUS = 'focus';
  var TRIGGER_CLICK = 'click';
  var TRIGGER_MANUAL = 'manual';
<<<<<<< HEAD
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  /**
   * ------------------------------------------------------------------------
   * Class Definition
   * ------------------------------------------------------------------------
   */

<<<<<<< HEAD
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  class Tooltip extends BaseComponent {
    constructor(element, config) {
      if (typeof Popper__namespace === 'undefined') {
        throw new TypeError('Bootstrap\'s tooltips require Popper (https://popper.js.org)');
      }
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  var Tooltip = /*#__PURE__*/function () {
    function Tooltip(element, config) {
      if (typeof Popper__default['default'] === 'undefined') {
        throw new TypeError('Bootstrap\'s tooltips require Popper (https://popper.js.org)');
      } // private
<<<<<<< HEAD

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

      super(element); // private
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277

      this._isEnabled = true;
      this._timeout = 0;
      this._hoverState = '';
      this._activeTrigger = {};
      this._popper = null; // Protected

<<<<<<< HEAD
      this.element = element;
      this.config = this._getConfig(config);
=======
      this._config = this._getConfig(config);
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      this.tip = null;

      this._setListeners();
    } // Getters


<<<<<<< HEAD
    var _proto = Tooltip.prototype;

    // Public
    _proto.enable = function enable() {
      this._isEnabled = true;
    };

    _proto.disable = function disable() {
      this._isEnabled = false;
    };

    _proto.toggleEnabled = function toggleEnabled() {
      this._isEnabled = !this._isEnabled;
    };

    _proto.toggle = function toggle(event) {
=======
    static get Default() {
      return Default$3;
    }

    static get NAME() {
      return NAME$4;
    }

    static get Event() {
      return Event$2;
    }

    static get DefaultType() {
      return DefaultType$3;
    } // Public


    enable() {
      this._isEnabled = true;
    }

    disable() {
      this._isEnabled = false;
    }

    toggleEnabled() {
      this._isEnabled = !this._isEnabled;
    }

    toggle(event) {
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      if (!this._isEnabled) {
        return;
      }

      if (event) {
<<<<<<< HEAD
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
        const context = this._initializeOnDelegatedTarget(event);
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
        var dataKey = this.constructor.DATA_KEY;
        var context = $__default['default'](event.currentTarget).data(dataKey);

        if (!context) {
          context = new this.constructor(event.currentTarget, this._getDelegateConfig());
          $__default['default'](event.currentTarget).data(dataKey, context);
        }
<<<<<<< HEAD
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277

        context._activeTrigger.click = !context._activeTrigger.click;

        if (context._isWithActiveTrigger()) {
          context._enter(null, context);
        } else {
          context._leave(null, context);
        }
      } else {
<<<<<<< HEAD
        if ($__default['default'](this.getTipElement()).hasClass(CLASS_NAME_SHOW$4)) {
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
        if (this.getTipElement().classList.contains(CLASS_NAME_SHOW$2)) {
========
        if ($__default['default'](this.getTipElement()).hasClass(CLASS_NAME_SHOW$4)) {
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
          this._leave(null, this);

          return;
        }

        this._enter(null, this);
      }
<<<<<<< HEAD
    };

    _proto.dispose = function dispose() {
      clearTimeout(this._timeout);
=======
    }

    dispose() {
      clearTimeout(this._timeout);
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      EventHandler.off(this._element.closest(SELECTOR_MODAL), EVENT_MODAL_HIDE, this._hideModalHandler);

      if (this.tip) {
        this.tip.remove();
      }

========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      $__default['default'].removeData(this.element, this.constructor.DATA_KEY);
      $__default['default'](this.element).off(this.constructor.EVENT_KEY);
      $__default['default'](this.element).closest('.modal').off('hide.bs.modal', this._hideModalHandler);

      if (this.tip) {
        $__default['default'](this.tip).remove();
      }

      this._isEnabled = null;
      this._timeout = null;
      this._hoverState = null;
      this._activeTrigger = null;

<<<<<<< HEAD
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      if (this._popper) {
        this._popper.destroy();
      }

<<<<<<< HEAD
      this._popper = null;
      this.element = null;
      this.config = null;
      this.tip = null;
    };

    _proto.show = function show() {
      var _this = this;

=======
      super.dispose();
    }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    show() {
      if (this._element.style.display === 'none') {
        throw new Error('Please use show on visible elements');
      }

      if (!(this.isWithContent() && this._isEnabled)) {
        return;
      }

      const showEvent = EventHandler.trigger(this._element, this.constructor.Event.SHOW);
      const shadowRoot = findShadowRoot(this._element);
      const isInTheDom = shadowRoot === null ? this._element.ownerDocument.documentElement.contains(this._element) : shadowRoot.contains(this._element);
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      if ($__default['default'](this.element).css('display') === 'none') {
        throw new Error('Please use show on visible elements');
      }

      var showEvent = $__default['default'].Event(this.constructor.Event.SHOW);

      if (this.isWithContent() && this._isEnabled) {
        $__default['default'](this.element).trigger(showEvent);
        var shadowRoot = Util.findShadowRoot(this.element);
        var isInTheDom = $__default['default'].contains(shadowRoot !== null ? shadowRoot : this.element.ownerDocument.documentElement, this.element);
<<<<<<< HEAD

        if (showEvent.isDefaultPrevented() || !isInTheDom) {
          return;
        }

        var tip = this.getTipElement();
        var tipId = Util.getUID(this.constructor.NAME);
        tip.setAttribute('id', tipId);
        this.element.setAttribute('aria-describedby', tipId);
        this.setContent();

        if (this.config.animation) {
          $__default['default'](tip).addClass(CLASS_NAME_FADE$2);
        }

        var placement = typeof this.config.placement === 'function' ? this.config.placement.call(this, tip, this.element) : this.config.placement;

        var attachment = this._getAttachment(placement);

        this.addAttachmentClass(attachment);

        var container = this._getContainer();

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

      if (showEvent.defaultPrevented || !isInTheDom) {
        return;
      }

      const tip = this.getTipElement();
      const tipId = getUID(this.constructor.NAME);
      tip.setAttribute('id', tipId);

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      this._element.setAttribute('aria-describedby', tipId);
========
        if (this.config.animation) {
          $__default['default'](tip).addClass(CLASS_NAME_FADE$2);
        }
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

      if (this._config.animation) {
        tip.classList.add(CLASS_NAME_FADE$2);
      }

      const placement = typeof this._config.placement === 'function' ? this._config.placement.call(this, tip, this._element) : this._config.placement;

      const attachment = this._getAttachment(placement);

      this._addAttachmentClass(attachment);

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      const {
        container
      } = this._config;
      Data.set(tip, this.constructor.DATA_KEY, this);

      if (!this._element.ownerDocument.documentElement.contains(this.tip)) {
        container.append(tip);
        EventHandler.trigger(this._element, this.constructor.Event.INSERTED);
      }

      if (this._popper) {
        this._popper.update();
      } else {
        this._popper = Popper__namespace.createPopper(this._element, tip, this._getPopperConfig(attachment));
      }

      tip.classList.add(CLASS_NAME_SHOW$2);
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
        $__default['default'](tip).data(this.constructor.DATA_KEY, this);

        if (!$__default['default'].contains(this.element.ownerDocument.documentElement, this.tip)) {
          $__default['default'](tip).appendTo(container);
        }

        $__default['default'](this.element).trigger(this.constructor.Event.INSERTED);
        this._popper = new Popper__default['default'](this.element, tip, this._getPopperConfig(attachment));
        $__default['default'](tip).addClass(CLASS_NAME_SHOW$4);
        $__default['default'](tip).addClass(this.config.customClass); // If this is a touch-enabled device we add extra
        // empty mouseover listeners to the body's immediate children;
        // only needed because of broken event delegation on iOS
        // https://www.quirksmode.org/blog/archives/2014/02/mouse_event_bub.html

        if ('ontouchstart' in document.documentElement) {
          $__default['default'](document.body).children().on('mouseover', null, $__default['default'].noop);
        }
<<<<<<< HEAD

        var complete = function complete() {
          if (_this.config.animation) {
            _this._fixTransition();
          }

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

      const customClass = this._resolvePossibleFunction(this._config.customClass);

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      if (customClass) {
        tip.classList.add(...customClass.split(' '));
      } // If this is a touch-enabled device we add extra
      // empty mouseover listeners to the body's immediate children;
      // only needed because of broken event delegation on iOS
      // https://www.quirksmode.org/blog/archives/2014/02/mouse_event_bub.html


      if ('ontouchstart' in document.documentElement) {
        [].concat(...document.body.children).forEach(element => {
          EventHandler.on(element, 'mouseover', noop);
        });
      }

      const complete = () => {
        const prevHoverState = this._hoverState;
        this._hoverState = null;
        EventHandler.trigger(this._element, this.constructor.Event.SHOWN);

        if (prevHoverState === HOVER_STATE_OUT) {
          this._leave(null, this);
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
          var prevHoverState = _this._hoverState;
          _this._hoverState = null;
          $__default['default'](_this.element).trigger(_this.constructor.Event.SHOWN);

          if (prevHoverState === HOVER_STATE_OUT) {
            _this._leave(null, _this);
          }
        };

        if ($__default['default'](this.tip).hasClass(CLASS_NAME_FADE$2)) {
          var transitionDuration = Util.getTransitionDurationFromElement(this.tip);
          $__default['default'](this.tip).one(Util.TRANSITION_END, complete).emulateTransitionEnd(transitionDuration);
        } else {
          complete();
<<<<<<< HEAD
        }
      }
    };

    _proto.hide = function hide(callback) {
      var _this2 = this;

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
        }
      };

      const isAnimated = this.tip.classList.contains(CLASS_NAME_FADE$2);

      this._queueCallback(complete, this.tip, isAnimated);
    }

    hide() {
      if (!this._popper) {
        return;
      }

      const tip = this.getTipElement();

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      const complete = () => {
        if (this._isWithActiveTrigger()) {
          return;
        }

        if (this._hoverState !== HOVER_STATE_SHOW) {
          tip.remove();
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      var tip = this.getTipElement();
      var hideEvent = $__default['default'].Event(this.constructor.Event.HIDE);

      var complete = function complete() {
        if (_this2._hoverState !== HOVER_STATE_SHOW && tip.parentNode) {
          tip.parentNode.removeChild(tip);
<<<<<<< HEAD
        }

        _this2._cleanTipClass();

        _this2.element.removeAttribute('aria-describedby');

        $__default['default'](_this2.element).trigger(_this2.constructor.Event.HIDDEN);

        if (_this2._popper !== null) {
          _this2._popper.destroy();
        }

        if (callback) {
          callback();
        }
      };

      $__default['default'](this.element).trigger(hideEvent);

      if (hideEvent.isDefaultPrevented()) {
        return;
      }

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
        }

        this._cleanTipClass();

        this._element.removeAttribute('aria-describedby');

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
        EventHandler.trigger(this._element, this.constructor.Event.HIDDEN);
========
        $__default['default'](_this2.element).trigger(_this2.constructor.Event.HIDDEN);
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

        if (this._popper) {
          this._popper.destroy();

          this._popper = null;
        }
      };

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      const hideEvent = EventHandler.trigger(this._element, this.constructor.Event.HIDE);
========
      $__default['default'](this.element).trigger(hideEvent);
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

      if (hideEvent.defaultPrevented) {
        return;
      }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      tip.classList.remove(CLASS_NAME_SHOW$2); // If this is a touch-enabled device we remove the extra
      // empty mouseover listeners we added for iOS support

      if ('ontouchstart' in document.documentElement) {
        [].concat(...document.body.children).forEach(element => EventHandler.off(element, 'mouseover', noop));
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      $__default['default'](tip).removeClass(CLASS_NAME_SHOW$4); // If this is a touch-enabled device we remove the extra
      // empty mouseover listeners we added for iOS support

      if ('ontouchstart' in document.documentElement) {
        $__default['default'](document.body).children().off('mouseover', null, $__default['default'].noop);
<<<<<<< HEAD
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      }

      this._activeTrigger[TRIGGER_CLICK] = false;
      this._activeTrigger[TRIGGER_FOCUS] = false;
      this._activeTrigger[TRIGGER_HOVER] = false;
<<<<<<< HEAD
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      const isAnimated = this.tip.classList.contains(CLASS_NAME_FADE$2);

      this._queueCallback(complete, this.tip, isAnimated);
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277

      if ($__default['default'](this.tip).hasClass(CLASS_NAME_FADE$2)) {
        var transitionDuration = Util.getTransitionDurationFromElement(tip);
        $__default['default'](tip).one(Util.TRANSITION_END, complete).emulateTransitionEnd(transitionDuration);
      } else {
        complete();
      }
<<<<<<< HEAD

      this._hoverState = '';
    };

    _proto.update = function update() {
      if (this._popper !== null) {
        this._popper.scheduleUpdate();
      }
    } // Protected
    ;

    _proto.isWithContent = function isWithContent() {
      return Boolean(this.getTitle());
    };

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

      this._hoverState = '';
    }

    update() {
      if (this._popper !== null) {
        this._popper.update();
      }
    } // Protected


    isWithContent() {
      return Boolean(this.getTitle());
    }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    getTipElement() {
      if (this.tip) {
        return this.tip;
      }

      const element = document.createElement('div');
      element.innerHTML = this._config.template;
      const tip = element.children[0];
      this.setContent(tip);
      tip.classList.remove(CLASS_NAME_FADE$2, CLASS_NAME_SHOW$2);
      this.tip = tip;
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    _proto.addAttachmentClass = function addAttachmentClass(attachment) {
      $__default['default'](this.getTipElement()).addClass(CLASS_PREFIX + "-" + attachment);
    };

    _proto.getTipElement = function getTipElement() {
      this.tip = this.tip || $__default['default'](this.config.template)[0];
<<<<<<< HEAD
      return this.tip;
    };

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
      return this.tip;
    }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    setContent(tip) {
      this._sanitizeAndSetContent(tip, this.getTitle(), SELECTOR_TOOLTIP_INNER);
    }

    _sanitizeAndSetContent(template, content, selector) {
      const templateElement = SelectorEngine.findOne(selector, template);

      if (!content && templateElement) {
        templateElement.remove();
        return;
      } // we use append for html objects to maintain js events


      this.setElementContent(templateElement, content);
    }

    setElementContent(element, content) {
      if (element === null) {
        return;
      }

      if (isElement(content)) {
        content = getElement(content); // content is a DOM node or a jQuery

        if (this._config.html) {
          if (content.parentNode !== element) {
            element.innerHTML = '';
            element.append(content);
          }
        } else {
          element.textContent = content.textContent;
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    _proto.setContent = function setContent() {
      var tip = this.getTipElement();
      this.setElementContent($__default['default'](tip.querySelectorAll(SELECTOR_TOOLTIP_INNER)), this.getTitle());
      $__default['default'](tip).removeClass(CLASS_NAME_FADE$2 + " " + CLASS_NAME_SHOW$4);
    };

    _proto.setElementContent = function setElementContent($element, content) {
      if (typeof content === 'object' && (content.nodeType || content.jquery)) {
        // Content is a DOM node or a jQuery
        if (this.config.html) {
          if (!$__default['default'](content).parent().is($element)) {
            $element.empty().append(content);
          }
        } else {
          $element.text($__default['default'](content).text());
<<<<<<< HEAD
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
        }

        return;
      }

<<<<<<< HEAD
      if (this.config.html) {
        if (this.config.sanitize) {
          content = sanitizeHtml(content, this.config.whiteList, this.config.sanitizeFn);
        }

        $element.html(content);
      } else {
        $element.text(content);
      }
    };

    _proto.getTitle = function getTitle() {
      var title = this.element.getAttribute('data-original-title');

      if (!title) {
        title = typeof this.config.title === 'function' ? this.config.title.call(this.element) : this.config.title;
      }

      return title;
    } // Private
    ;

=======
      if (this._config.html) {
        if (this._config.sanitize) {
          content = sanitizeHtml(content, this._config.allowList, this._config.sanitizeFn);
        }

        element.innerHTML = content;
      } else {
        element.textContent = content;
      }
    }

    getTitle() {
      const title = this._element.getAttribute('data-bs-original-title') || this._config.title;

      return this._resolvePossibleFunction(title);
    }

    updateAttachment(attachment) {
      if (attachment === 'right') {
        return 'end';
      }

      if (attachment === 'left') {
        return 'start';
      }

      return attachment;
    } // Private

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js

    _initializeOnDelegatedTarget(event, context) {
      return context || this.constructor.getOrCreateInstance(event.delegateTarget, this._getDelegateConfig());
    }

    _getOffset() {
      const {
        offset
      } = this._config;

      if (typeof offset === 'string') {
        return offset.split(',').map(val => Number.parseInt(val, 10));
      }

      if (typeof offset === 'function') {
        return popperData => offset(popperData, this._element);
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    _proto._getPopperConfig = function _getPopperConfig(attachment) {
      var _this3 = this;

      var defaultBsConfig = {
        placement: attachment,
        modifiers: {
          offset: this._getOffset(),
          flip: {
            behavior: this.config.fallbackPlacement
          },
          arrow: {
            element: SELECTOR_ARROW
          },
          preventOverflow: {
            boundariesElement: this.config.boundary
          }
        },
        onCreate: function onCreate(data) {
          if (data.originalPlacement !== data.placement) {
            _this3._handlePopperPlacementChange(data);
          }
        },
        onUpdate: function onUpdate(data) {
          return _this3._handlePopperPlacementChange(data);
        }
      };
      return _extends({}, defaultBsConfig, this.config.popperConfig);
    };

    _proto._getOffset = function _getOffset() {
      var _this4 = this;

      var offset = {};

      if (typeof this.config.offset === 'function') {
        offset.fn = function (data) {
          data.offsets = _extends({}, data.offsets, _this4.config.offset(data.offsets, _this4.element) || {});
          return data;
        };
      } else {
        offset.offset = this.config.offset;
<<<<<<< HEAD
      }

      return offset;
    };

    _proto._getContainer = function _getContainer() {
      if (this.config.container === false) {
        return document.body;
      }

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
      }

      return offset;
    }

    _resolvePossibleFunction(content) {
      return typeof content === 'function' ? content.call(this._element) : content;
    }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    _getPopperConfig(attachment) {
      const defaultBsPopperConfig = {
        placement: attachment,
        modifiers: [{
          name: 'flip',
          options: {
            fallbackPlacements: this._config.fallbackPlacements
          }
        }, {
          name: 'offset',
          options: {
            offset: this._getOffset()
          }
        }, {
          name: 'preventOverflow',
          options: {
            boundary: this._config.boundary
          }
        }, {
          name: 'arrow',
          options: {
            element: `.${this.constructor.NAME}-arrow`
          }
        }, {
          name: 'onChange',
          enabled: true,
          phase: 'afterWrite',
          fn: data => this._handlePopperPlacementChange(data)
        }],
        onFirstUpdate: data => {
          if (data.options.placement !== data.placement) {
            this._handlePopperPlacementChange(data);
          }
        }
      };
      return { ...defaultBsPopperConfig,
        ...(typeof this._config.popperConfig === 'function' ? this._config.popperConfig(defaultBsPopperConfig) : this._config.popperConfig)
      };
    }

    _addAttachmentClass(attachment) {
      this.getTipElement().classList.add(`${this._getBasicClassPrefix()}-${this.updateAttachment(attachment)}`);
    }

    _getAttachment(placement) {
      return AttachmentMap[placement.toUpperCase()];
    }

    _setListeners() {
      const triggers = this._config.trigger.split(' ');
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      if (Util.isElement(this.config.container)) {
        return $__default['default'](this.config.container);
      }

      return $__default['default'](document).find(this.config.container);
    };

    _proto._getAttachment = function _getAttachment(placement) {
      return AttachmentMap[placement.toUpperCase()];
    };

    _proto._setListeners = function _setListeners() {
      var _this5 = this;
<<<<<<< HEAD

      var triggers = this.config.trigger.split(' ');
      triggers.forEach(function (trigger) {
        if (trigger === 'click') {
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

      triggers.forEach(trigger => {
        if (trigger === 'click') {
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
          EventHandler.on(this._element, this.constructor.Event.CLICK, this._config.selector, event => this.toggle(event));
        } else if (trigger !== TRIGGER_MANUAL) {
          const eventIn = trigger === TRIGGER_HOVER ? this.constructor.Event.MOUSEENTER : this.constructor.Event.FOCUSIN;
          const eventOut = trigger === TRIGGER_HOVER ? this.constructor.Event.MOUSELEAVE : this.constructor.Event.FOCUSOUT;
          EventHandler.on(this._element, eventIn, this._config.selector, event => this._enter(event));
          EventHandler.on(this._element, eventOut, this._config.selector, event => this._leave(event));
        }
      });

      this._hideModalHandler = () => {
        if (this._element) {
          this.hide();
        }
      };

      EventHandler.on(this._element.closest(SELECTOR_MODAL), EVENT_MODAL_HIDE, this._hideModalHandler);

      if (this._config.selector) {
        this._config = { ...this._config,
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
          $__default['default'](_this5.element).on(_this5.constructor.Event.CLICK, _this5.config.selector, function (event) {
            return _this5.toggle(event);
          });
        } else if (trigger !== TRIGGER_MANUAL) {
          var eventIn = trigger === TRIGGER_HOVER ? _this5.constructor.Event.MOUSEENTER : _this5.constructor.Event.FOCUSIN;
          var eventOut = trigger === TRIGGER_HOVER ? _this5.constructor.Event.MOUSELEAVE : _this5.constructor.Event.FOCUSOUT;
          $__default['default'](_this5.element).on(eventIn, _this5.config.selector, function (event) {
            return _this5._enter(event);
          }).on(eventOut, _this5.config.selector, function (event) {
            return _this5._leave(event);
          });
        }
      });

      this._hideModalHandler = function () {
        if (_this5.element) {
          _this5.hide();
        }
      };

      $__default['default'](this.element).closest('.modal').on('hide.bs.modal', this._hideModalHandler);

      if (this.config.selector) {
        this.config = _extends({}, this.config, {
<<<<<<< HEAD
          trigger: 'manual',
          selector: ''
        });
      } else {
        this._fixTitle();
      }
    };

    _proto._fixTitle = function _fixTitle() {
      var titleType = typeof this.element.getAttribute('data-original-title');

      if (this.element.getAttribute('title') || titleType !== 'string') {
        this.element.setAttribute('data-original-title', this.element.getAttribute('title') || '');
        this.element.setAttribute('title', '');
      }
    };

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
          trigger: 'manual',
          selector: ''
        };
      } else {
        this._fixTitle();
      }
    }

    _fixTitle() {
      const title = this._element.getAttribute('title');

      const originalTitleType = typeof this._element.getAttribute('data-bs-original-title');

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      if (title || originalTitleType !== 'string') {
        this._element.setAttribute('data-bs-original-title', title || '');

        if (title && !this._element.getAttribute('aria-label') && !this._element.textContent) {
          this._element.setAttribute('aria-label', title);
        }

        this._element.setAttribute('title', '');
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    _proto._enter = function _enter(event, context) {
      var dataKey = this.constructor.DATA_KEY;
      context = context || $__default['default'](event.currentTarget).data(dataKey);

      if (!context) {
        context = new this.constructor(event.currentTarget, this._getDelegateConfig());
        $__default['default'](event.currentTarget).data(dataKey, context);
<<<<<<< HEAD
      }
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
      }
    }

    _enter(event, context) {
      context = this._initializeOnDelegatedTarget(event, context);
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277

      if (event) {
        context._activeTrigger[event.type === 'focusin' ? TRIGGER_FOCUS : TRIGGER_HOVER] = true;
      }

<<<<<<< HEAD
      if ($__default['default'](context.getTipElement()).hasClass(CLASS_NAME_SHOW$4) || context._hoverState === HOVER_STATE_SHOW) {
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      if (context.getTipElement().classList.contains(CLASS_NAME_SHOW$2) || context._hoverState === HOVER_STATE_SHOW) {
========
      if ($__default['default'](context.getTipElement()).hasClass(CLASS_NAME_SHOW$4) || context._hoverState === HOVER_STATE_SHOW) {
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
        context._hoverState = HOVER_STATE_SHOW;
        return;
      }

      clearTimeout(context._timeout);
      context._hoverState = HOVER_STATE_SHOW;

<<<<<<< HEAD
      if (!context.config.delay || !context.config.delay.show) {
=======
      if (!context._config.delay || !context._config.delay.show) {
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
        context.show();
        return;
      }

<<<<<<< HEAD
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      context._timeout = setTimeout(() => {
        if (context._hoverState === HOVER_STATE_SHOW) {
          context.show();
        }
      }, context._config.delay.show);
    }

    _leave(event, context) {
      context = this._initializeOnDelegatedTarget(event, context);

      if (event) {
        context._activeTrigger[event.type === 'focusout' ? TRIGGER_FOCUS : TRIGGER_HOVER] = context._element.contains(event.relatedTarget);
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      context._timeout = setTimeout(function () {
        if (context._hoverState === HOVER_STATE_SHOW) {
          context.show();
        }
      }, context.config.delay.show);
    };

    _proto._leave = function _leave(event, context) {
      var dataKey = this.constructor.DATA_KEY;
      context = context || $__default['default'](event.currentTarget).data(dataKey);

      if (!context) {
        context = new this.constructor(event.currentTarget, this._getDelegateConfig());
        $__default['default'](event.currentTarget).data(dataKey, context);
      }

      if (event) {
        context._activeTrigger[event.type === 'focusout' ? TRIGGER_FOCUS : TRIGGER_HOVER] = false;
<<<<<<< HEAD
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      }

      if (context._isWithActiveTrigger()) {
        return;
      }

      clearTimeout(context._timeout);
      context._hoverState = HOVER_STATE_OUT;

<<<<<<< HEAD
      if (!context.config.delay || !context.config.delay.hide) {
=======
      if (!context._config.delay || !context._config.delay.hide) {
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
        context.hide();
        return;
      }

<<<<<<< HEAD
      context._timeout = setTimeout(function () {
        if (context._hoverState === HOVER_STATE_OUT) {
          context.hide();
        }
      }, context.config.delay.hide);
    };

    _proto._isWithActiveTrigger = function _isWithActiveTrigger() {
      for (var trigger in this._activeTrigger) {
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      context._timeout = setTimeout(() => {
========
      context._timeout = setTimeout(function () {
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
        if (context._hoverState === HOVER_STATE_OUT) {
          context.hide();
        }
      }, context._config.delay.hide);
    }

    _isWithActiveTrigger() {
      for (const trigger in this._activeTrigger) {
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
        if (this._activeTrigger[trigger]) {
          return true;
        }
      }

      return false;
<<<<<<< HEAD
    };

=======
    }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    _getConfig(config) {
      const dataAttributes = Manipulator.getDataAttributes(this._element);
      Object.keys(dataAttributes).forEach(dataAttr => {
        if (DISALLOWED_ATTRIBUTES.has(dataAttr)) {
          delete dataAttributes[dataAttr];
        }
      });
      config = { ...this.constructor.Default,
        ...dataAttributes,
        ...(typeof config === 'object' && config ? config : {})
      };
      config.container = config.container === false ? document.body : getElement(config.container);
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    _proto._getConfig = function _getConfig(config) {
      var dataAttributes = $__default['default'](this.element).data();
      Object.keys(dataAttributes).forEach(function (dataAttr) {
        if (DISALLOWED_ATTRIBUTES.indexOf(dataAttr) !== -1) {
          delete dataAttributes[dataAttr];
        }
      });
      config = _extends({}, this.constructor.Default, dataAttributes, typeof config === 'object' && config ? config : {});
<<<<<<< HEAD
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277

      if (typeof config.delay === 'number') {
        config.delay = {
          show: config.delay,
          hide: config.delay
        };
      }

      if (typeof config.title === 'number') {
        config.title = config.title.toString();
      }

      if (typeof config.content === 'number') {
        config.content = config.content.toString();
      }

<<<<<<< HEAD
      Util.typeCheckConfig(NAME$6, config, this.constructor.DefaultType);

      if (config.sanitize) {
        config.template = sanitizeHtml(config.template, config.whiteList, config.sanitizeFn);
      }

      return config;
    };

    _proto._getDelegateConfig = function _getDelegateConfig() {
      var config = {};

      if (this.config) {
        for (var key in this.config) {
          if (this.constructor.Default[key] !== this.config[key]) {
            config[key] = this.config[key];
          }
        }
      }

      return config;
    };

    _proto._cleanTipClass = function _cleanTipClass() {
      var $tip = $__default['default'](this.getTipElement());
      var tabClass = $tip.attr('class').match(BSCLS_PREFIX_REGEX);

      if (tabClass !== null && tabClass.length) {
        $tip.removeClass(tabClass.join(''));
      }
=======
      typeCheckConfig(NAME$4, config, this.constructor.DefaultType);

      if (config.sanitize) {
        config.template = sanitizeHtml(config.template, config.allowList, config.sanitizeFn);
      }

      return config;
    }

    _getDelegateConfig() {
      const config = {};

      for (const key in this._config) {
        if (this.constructor.Default[key] !== this._config[key]) {
          config[key] = this._config[key];
        }
      } // In the future can be replaced with:
      // const keysWithDifferentValues = Object.entries(this._config).filter(entry => this.constructor.Default[entry[0]] !== this._config[entry[0]])
      // `Object.fromEntries(keysWithDifferentValues)`


      return config;
    }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    _cleanTipClass() {
      const tip = this.getTipElement();
      const basicClassPrefixRegex = new RegExp(`(^|\\s)${this._getBasicClassPrefix()}\\S+`, 'g');
      const tabClass = tip.getAttribute('class').match(basicClassPrefixRegex);
========
    _proto._cleanTipClass = function _cleanTipClass() {
      var $tip = $__default['default'](this.getTipElement());
      var tabClass = $tip.attr('class').match(BSCLS_PREFIX_REGEX);
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

      if (tabClass !== null && tabClass.length > 0) {
        tabClass.map(token => token.trim()).forEach(tClass => tip.classList.remove(tClass));
      }
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    }
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    };

    _proto._handlePopperPlacementChange = function _handlePopperPlacementChange(popperData) {
      this.tip = popperData.instance.popper;

      this._cleanTipClass();
<<<<<<< HEAD

      this.addAttachmentClass(this._getAttachment(popperData.placement));
    };

    _proto._fixTransition = function _fixTransition() {
      var tip = this.getTipElement();
      var initConfigAnimation = this.config.animation;

      if (tip.getAttribute('x-placement') !== null) {
        return;
      }

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

    _getBasicClassPrefix() {
      return CLASS_PREFIX$1;
    }

    _handlePopperPlacementChange(popperData) {
      const {
        state
      } = popperData;

      if (!state) {
        return;
      }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      this.tip = state.elements.popper;

      this._cleanTipClass();
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      $__default['default'](tip).removeClass(CLASS_NAME_FADE$2);
      this.config.animation = false;
      this.hide();
      this.show();
      this.config.animation = initConfigAnimation;
    } // Static
    ;

    Tooltip._jQueryInterface = function _jQueryInterface(config) {
      return this.each(function () {
        var $element = $__default['default'](this);
        var data = $element.data(DATA_KEY$6);
<<<<<<< HEAD

        var _config = typeof config === 'object' && config;

        if (!data && /dispose|hide/.test(config)) {
          return;
        }

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

      this._addAttachmentClass(this._getAttachment(state.placement));
    } // Static


<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    static jQueryInterface(config) {
      return this.each(function () {
        const data = Tooltip.getOrCreateInstance(this, config);
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
        if (!data) {
          data = new Tooltip(this, _config);
          $element.data(DATA_KEY$6, data);
        }
<<<<<<< HEAD

        if (typeof config === 'string') {
          if (typeof data[config] === 'undefined') {
            throw new TypeError("No method named \"" + config + "\"");
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

        if (typeof config === 'string') {
          if (typeof data[config] === 'undefined') {
            throw new TypeError(`No method named "${config}"`);
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
          }

          data[config]();
        }
      });
<<<<<<< HEAD
    };

=======
    }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  }
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    _createClass(Tooltip, null, [{
      key: "VERSION",
      get: function get() {
        return VERSION$6;
      }
    }, {
      key: "Default",
      get: function get() {
        return Default$4;
      }
    }, {
      key: "NAME",
      get: function get() {
        return NAME$6;
      }
    }, {
      key: "DATA_KEY",
      get: function get() {
        return DATA_KEY$6;
      }
    }, {
      key: "Event",
      get: function get() {
        return Event;
      }
    }, {
      key: "EVENT_KEY",
      get: function get() {
        return EVENT_KEY$6;
      }
    }, {
      key: "DefaultType",
      get: function get() {
        return DefaultType$4;
      }
    }]);

    return Tooltip;
  }();
<<<<<<< HEAD
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  /**
   * ------------------------------------------------------------------------
   * jQuery
   * ------------------------------------------------------------------------
<<<<<<< HEAD
   */


=======
   * add .Tooltip to jQuery only if jQuery is present
   */


<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  defineJQueryPlugin(Tooltip);
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  $__default['default'].fn[NAME$6] = Tooltip._jQueryInterface;
  $__default['default'].fn[NAME$6].Constructor = Tooltip;

  $__default['default'].fn[NAME$6].noConflict = function () {
    $__default['default'].fn[NAME$6] = JQUERY_NO_CONFLICT$6;
    return Tooltip._jQueryInterface;
  };
<<<<<<< HEAD

  /**
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

  /**
   * --------------------------------------------------------------------------
   * Bootstrap (v5.1.0): popover.js
   * Licensed under MIT (https://github.com/twbs/bootstrap/blob/main/LICENSE)
   * --------------------------------------------------------------------------
   */
  /**
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
   * ------------------------------------------------------------------------
   * Constants
   * ------------------------------------------------------------------------
   */

<<<<<<< HEAD
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  const NAME$3 = 'popover';
  const DATA_KEY$3 = 'bs.popover';
  const EVENT_KEY$3 = `.${DATA_KEY$3}`;
  const CLASS_PREFIX = 'bs-popover';
  const Default$2 = { ...Tooltip.Default,
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  var NAME$7 = 'popover';
  var VERSION$7 = '4.6.0';
  var DATA_KEY$7 = 'bs.popover';
  var EVENT_KEY$7 = "." + DATA_KEY$7;
  var JQUERY_NO_CONFLICT$7 = $__default['default'].fn[NAME$7];
  var CLASS_PREFIX$1 = 'bs-popover';
  var BSCLS_PREFIX_REGEX$1 = new RegExp("(^|\\s)" + CLASS_PREFIX$1 + "\\S+", 'g');

  var Default$5 = _extends({}, Tooltip.Default, {
<<<<<<< HEAD
    placement: 'right',
    trigger: 'click',
    content: '',
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
    placement: 'right',
    offset: [0, 8],
    trigger: 'click',
    content: '',
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    template: '<div class="popover" role="tooltip">' + '<div class="popover-arrow"></div>' + '<h3 class="popover-header"></h3>' + '<div class="popover-body"></div>' + '</div>'
  };
  const DefaultType$2 = { ...Tooltip.DefaultType,
    content: '(string|element|function)'
  };
  const Event$1 = {
    HIDE: `hide${EVENT_KEY$3}`,
    HIDDEN: `hidden${EVENT_KEY$3}`,
    SHOW: `show${EVENT_KEY$3}`,
    SHOWN: `shown${EVENT_KEY$3}`,
    INSERTED: `inserted${EVENT_KEY$3}`,
    CLICK: `click${EVENT_KEY$3}`,
    FOCUSIN: `focusin${EVENT_KEY$3}`,
    FOCUSOUT: `focusout${EVENT_KEY$3}`,
    MOUSEENTER: `mouseenter${EVENT_KEY$3}`,
    MOUSELEAVE: `mouseleave${EVENT_KEY$3}`
  };
  const SELECTOR_TITLE = '.popover-header';
  const SELECTOR_CONTENT = '.popover-body';
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    template: '<div class="popover" role="tooltip">' + '<div class="arrow"></div>' + '<h3 class="popover-header"></h3>' + '<div class="popover-body"></div></div>'
  });

  var DefaultType$5 = _extends({}, Tooltip.DefaultType, {
    content: '(string|element|function)'
  });

  var CLASS_NAME_FADE$3 = 'fade';
  var CLASS_NAME_SHOW$5 = 'show';
  var SELECTOR_TITLE = '.popover-header';
  var SELECTOR_CONTENT = '.popover-body';
  var Event$1 = {
    HIDE: "hide" + EVENT_KEY$7,
    HIDDEN: "hidden" + EVENT_KEY$7,
    SHOW: "show" + EVENT_KEY$7,
    SHOWN: "shown" + EVENT_KEY$7,
    INSERTED: "inserted" + EVENT_KEY$7,
    CLICK: "click" + EVENT_KEY$7,
    FOCUSIN: "focusin" + EVENT_KEY$7,
    FOCUSOUT: "focusout" + EVENT_KEY$7,
    MOUSEENTER: "mouseenter" + EVENT_KEY$7,
    MOUSELEAVE: "mouseleave" + EVENT_KEY$7
  };
<<<<<<< HEAD
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  /**
   * ------------------------------------------------------------------------
   * Class Definition
   * ------------------------------------------------------------------------
   */

<<<<<<< HEAD
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  class Popover extends Tooltip {
    // Getters
    static get Default() {
      return Default$2;
    }

    static get NAME() {
      return NAME$3;
    }

    static get Event() {
      return Event$1;
    }

    static get DefaultType() {
      return DefaultType$2;
    } // Overrides

========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  var Popover = /*#__PURE__*/function (_Tooltip) {
    _inheritsLoose(Popover, _Tooltip);

    function Popover() {
      return _Tooltip.apply(this, arguments) || this;
    }

    var _proto = Popover.prototype;

    // Overrides
    _proto.isWithContent = function isWithContent() {
      return this.getTitle() || this._getContent();
    };

    _proto.addAttachmentClass = function addAttachmentClass(attachment) {
      $__default['default'](this.getTipElement()).addClass(CLASS_PREFIX$1 + "-" + attachment);
    };

    _proto.getTipElement = function getTipElement() {
      this.tip = this.tip || $__default['default'](this.config.template)[0];
      return this.tip;
    };

    _proto.setContent = function setContent() {
      var $tip = $__default['default'](this.getTipElement()); // We use append for html objects to maintain js events

      this.setElementContent($tip.find(SELECTOR_TITLE), this.getTitle());
<<<<<<< HEAD

      var content = this._getContent();

      if (typeof content === 'function') {
        content = content.call(this.element);
      }

      this.setElementContent($tip.find(SELECTOR_CONTENT), content);
      $tip.removeClass(CLASS_NAME_FADE$3 + " " + CLASS_NAME_SHOW$5);
    } // Private
    ;

    _proto._getContent = function _getContent() {
      return this.element.getAttribute('data-content') || this.config.content;
    };

    _proto._cleanTipClass = function _cleanTipClass() {
      var $tip = $__default['default'](this.getTipElement());
      var tabClass = $tip.attr('class').match(BSCLS_PREFIX_REGEX$1);

      if (tabClass !== null && tabClass.length > 0) {
        $tip.removeClass(tabClass.join(''));
      }
    } // Static
    ;

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

    isWithContent() {
      return this.getTitle() || this._getContent();
    }

    setContent(tip) {
      this._sanitizeAndSetContent(tip, this.getTitle(), SELECTOR_TITLE);

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      this._sanitizeAndSetContent(tip, this._getContent(), SELECTOR_CONTENT);
========
      this.setElementContent($tip.find(SELECTOR_CONTENT), content);
      $tip.removeClass(CLASS_NAME_FADE$3 + " " + CLASS_NAME_SHOW$5);
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
    } // Private


<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    _getContent() {
      return this._resolvePossibleFunction(this._config.content);
    }
========
    _proto._cleanTipClass = function _cleanTipClass() {
      var $tip = $__default['default'](this.getTipElement());
      var tabClass = $tip.attr('class').match(BSCLS_PREFIX_REGEX$1);
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

    _getBasicClassPrefix() {
      return CLASS_PREFIX;
    } // Static

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js

    static jQueryInterface(config) {
      return this.each(function () {
        const data = Popover.getOrCreateInstance(this, config);
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    Popover._jQueryInterface = function _jQueryInterface(config) {
      return this.each(function () {
        var data = $__default['default'](this).data(DATA_KEY$7);

        var _config = typeof config === 'object' ? config : null;

        if (!data && /dispose|hide/.test(config)) {
          return;
        }

        if (!data) {
          data = new Popover(this, _config);
          $__default['default'](this).data(DATA_KEY$7, data);
        }
<<<<<<< HEAD

        if (typeof config === 'string') {
          if (typeof data[config] === 'undefined') {
            throw new TypeError("No method named \"" + config + "\"");
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

        if (typeof config === 'string') {
          if (typeof data[config] === 'undefined') {
            throw new TypeError(`No method named "${config}"`);
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
          }

          data[config]();
        }
      });
<<<<<<< HEAD
    };

=======
    }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  }
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    _createClass(Popover, null, [{
      key: "VERSION",
      // Getters
      get: function get() {
        return VERSION$7;
      }
    }, {
      key: "Default",
      get: function get() {
        return Default$5;
      }
    }, {
      key: "NAME",
      get: function get() {
        return NAME$7;
      }
    }, {
      key: "DATA_KEY",
      get: function get() {
        return DATA_KEY$7;
      }
    }, {
      key: "Event",
      get: function get() {
        return Event$1;
      }
    }, {
      key: "EVENT_KEY",
      get: function get() {
        return EVENT_KEY$7;
      }
    }, {
      key: "DefaultType",
      get: function get() {
        return DefaultType$5;
      }
    }]);

    return Popover;
  }(Tooltip);
<<<<<<< HEAD
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  /**
   * ------------------------------------------------------------------------
   * jQuery
   * ------------------------------------------------------------------------
<<<<<<< HEAD
   */


=======
   * add .Popover to jQuery only if jQuery is present
   */


<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  defineJQueryPlugin(Popover);
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  $__default['default'].fn[NAME$7] = Popover._jQueryInterface;
  $__default['default'].fn[NAME$7].Constructor = Popover;

  $__default['default'].fn[NAME$7].noConflict = function () {
    $__default['default'].fn[NAME$7] = JQUERY_NO_CONFLICT$7;
    return Popover._jQueryInterface;
  };
<<<<<<< HEAD

  /**
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

  /**
   * --------------------------------------------------------------------------
   * Bootstrap (v5.1.0): scrollspy.js
   * Licensed under MIT (https://github.com/twbs/bootstrap/blob/main/LICENSE)
   * --------------------------------------------------------------------------
   */
  /**
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
   * ------------------------------------------------------------------------
   * Constants
   * ------------------------------------------------------------------------
   */

<<<<<<< HEAD
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  const NAME$2 = 'scrollspy';
  const DATA_KEY$2 = 'bs.scrollspy';
  const EVENT_KEY$2 = `.${DATA_KEY$2}`;
  const DATA_API_KEY$1 = '.data-api';
  const Default$1 = {
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  var NAME$8 = 'scrollspy';
  var VERSION$8 = '4.6.0';
  var DATA_KEY$8 = 'bs.scrollspy';
  var EVENT_KEY$8 = "." + DATA_KEY$8;
  var DATA_API_KEY$6 = '.data-api';
  var JQUERY_NO_CONFLICT$8 = $__default['default'].fn[NAME$8];
  var Default$6 = {
<<<<<<< HEAD
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    offset: 10,
    method: 'auto',
    target: ''
  };
<<<<<<< HEAD
  var DefaultType$6 = {
=======
  const DefaultType$1 = {
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    offset: 'number',
    method: 'string',
    target: '(string|element)'
  };
<<<<<<< HEAD
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  const EVENT_ACTIVATE = `activate${EVENT_KEY$2}`;
  const EVENT_SCROLL = `scroll${EVENT_KEY$2}`;
  const EVENT_LOAD_DATA_API = `load${EVENT_KEY$2}${DATA_API_KEY$1}`;
  const CLASS_NAME_DROPDOWN_ITEM = 'dropdown-item';
  const CLASS_NAME_ACTIVE$1 = 'active';
  const SELECTOR_DATA_SPY = '[data-bs-spy="scroll"]';
  const SELECTOR_NAV_LIST_GROUP$1 = '.nav, .list-group';
  const SELECTOR_NAV_LINKS = '.nav-link';
  const SELECTOR_NAV_ITEMS = '.nav-item';
  const SELECTOR_LIST_ITEMS = '.list-group-item';
  const SELECTOR_LINK_ITEMS = `${SELECTOR_NAV_LINKS}, ${SELECTOR_LIST_ITEMS}, .${CLASS_NAME_DROPDOWN_ITEM}`;
  const SELECTOR_DROPDOWN$1 = '.dropdown';
  const SELECTOR_DROPDOWN_TOGGLE$1 = '.dropdown-toggle';
  const METHOD_OFFSET = 'offset';
  const METHOD_POSITION = 'position';
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  var EVENT_ACTIVATE = "activate" + EVENT_KEY$8;
  var EVENT_SCROLL = "scroll" + EVENT_KEY$8;
  var EVENT_LOAD_DATA_API$2 = "load" + EVENT_KEY$8 + DATA_API_KEY$6;
  var CLASS_NAME_DROPDOWN_ITEM = 'dropdown-item';
  var CLASS_NAME_ACTIVE$2 = 'active';
  var SELECTOR_DATA_SPY = '[data-spy="scroll"]';
  var SELECTOR_NAV_LIST_GROUP = '.nav, .list-group';
  var SELECTOR_NAV_LINKS = '.nav-link';
  var SELECTOR_NAV_ITEMS = '.nav-item';
  var SELECTOR_LIST_ITEMS = '.list-group-item';
  var SELECTOR_DROPDOWN = '.dropdown';
  var SELECTOR_DROPDOWN_ITEMS = '.dropdown-item';
  var SELECTOR_DROPDOWN_TOGGLE = '.dropdown-toggle';
  var METHOD_OFFSET = 'offset';
  var METHOD_POSITION = 'position';
<<<<<<< HEAD
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  /**
   * ------------------------------------------------------------------------
   * Class Definition
   * ------------------------------------------------------------------------
   */
<<<<<<< HEAD
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277

  var ScrollSpy = /*#__PURE__*/function () {
    function ScrollSpy(element, config) {
      var _this = this;
<<<<<<< HEAD

      this._element = element;
      this._scrollElement = element.tagName === 'BODY' ? window : element;
      this._config = this._getConfig(config);
      this._selector = this._config.target + " " + SELECTOR_NAV_LINKS + "," + (this._config.target + " " + SELECTOR_LIST_ITEMS + ",") + (this._config.target + " " + SELECTOR_DROPDOWN_ITEMS);
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

  class ScrollSpy extends BaseComponent {
    constructor(element, config) {
      super(element);
      this._scrollElement = this._element.tagName === 'BODY' ? window : this._element;
      this._config = this._getConfig(config);
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
========
      this._selector = this._config.target + " " + SELECTOR_NAV_LINKS + "," + (this._config.target + " " + SELECTOR_LIST_ITEMS + ",") + (this._config.target + " " + SELECTOR_DROPDOWN_ITEMS);
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      this._offsets = [];
      this._targets = [];
      this._activeTarget = null;
      this._scrollHeight = 0;
<<<<<<< HEAD
      $__default['default'](this._scrollElement).on(EVENT_SCROLL, function (event) {
        return _this._process(event);
      });
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      EventHandler.on(this._scrollElement, EVENT_SCROLL, () => this._process());
========
      $__default['default'](this._scrollElement).on(EVENT_SCROLL, function (event) {
        return _this._process(event);
      });
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      this.refresh();

      this._process();
    } // Getters


<<<<<<< HEAD
    var _proto = ScrollSpy.prototype;

    // Public
    _proto.refresh = function refresh() {
      var _this2 = this;

      var autoMethod = this._scrollElement === this._scrollElement.window ? METHOD_OFFSET : METHOD_POSITION;
      var offsetMethod = this._config.method === 'auto' ? autoMethod : this._config.method;
      var offsetBase = offsetMethod === METHOD_POSITION ? this._getScrollTop() : 0;
      this._offsets = [];
      this._targets = [];
      this._scrollHeight = this._getScrollHeight();
      var targets = [].slice.call(document.querySelectorAll(this._selector));
      targets.map(function (element) {
        var target;
        var targetSelector = Util.getSelectorFromElement(element);

        if (targetSelector) {
          target = document.querySelector(targetSelector);
        }

        if (target) {
          var targetBCR = target.getBoundingClientRect();

          if (targetBCR.width || targetBCR.height) {
            // TODO (fat): remove sketch reliance on jQuery position/offset
            return [$__default['default'](target)[offsetMethod]().top + offsetBase, targetSelector];
=======
    static get Default() {
      return Default$1;
    }

    static get NAME() {
      return NAME$2;
    } // Public


<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    refresh() {
      const autoMethod = this._scrollElement === this._scrollElement.window ? METHOD_OFFSET : METHOD_POSITION;
      const offsetMethod = this._config.method === 'auto' ? autoMethod : this._config.method;
      const offsetBase = offsetMethod === METHOD_POSITION ? this._getScrollTop() : 0;
========
      var autoMethod = this._scrollElement === this._scrollElement.window ? METHOD_OFFSET : METHOD_POSITION;
      var offsetMethod = this._config.method === 'auto' ? autoMethod : this._config.method;
      var offsetBase = offsetMethod === METHOD_POSITION ? this._getScrollTop() : 0;
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
      this._offsets = [];
      this._targets = [];
      this._scrollHeight = this._getScrollHeight();
      const targets = SelectorEngine.find(SELECTOR_LINK_ITEMS, this._config.target);
      targets.map(element => {
        const targetSelector = getSelectorFromElement(element);
        const target = targetSelector ? SelectorEngine.findOne(targetSelector) : null;

        if (target) {
          const targetBCR = target.getBoundingClientRect();

          if (targetBCR.width || targetBCR.height) {
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
            return [Manipulator[offsetMethod](target).top + offsetBase, targetSelector];
========
            // TODO (fat): remove sketch reliance on jQuery position/offset
            return [$__default['default'](target)[offsetMethod]().top + offsetBase, targetSelector];
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
          }
        }

        return null;
<<<<<<< HEAD
      }).filter(function (item) {
        return item;
      }).sort(function (a, b) {
        return a[0] - b[0];
      }).forEach(function (item) {
        _this2._offsets.push(item[0]);

        _this2._targets.push(item[1]);
      });
    };

=======
      }).filter(item => item).sort((a, b) => a[0] - b[0]).forEach(item => {
        this._offsets.push(item[0]);

        this._targets.push(item[1]);
      });
    }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    dispose() {
      EventHandler.off(this._scrollElement, EVENT_KEY$2);
      super.dispose();
    } // Private
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    _proto.dispose = function dispose() {
      $__default['default'].removeData(this._element, DATA_KEY$8);
      $__default['default'](this._scrollElement).off(EVENT_KEY$8);
      this._element = null;
      this._scrollElement = null;
      this._config = null;
      this._selector = null;
      this._offsets = null;
      this._targets = null;
      this._activeTarget = null;
      this._scrollHeight = null;
    } // Private
    ;

    _proto._getConfig = function _getConfig(config) {
      config = _extends({}, Default$6, typeof config === 'object' && config ? config : {});

      if (typeof config.target !== 'string' && Util.isElement(config.target)) {
        var id = $__default['default'](config.target).attr('id');

        if (!id) {
          id = Util.getUID(NAME$8);
          $__default['default'](config.target).attr('id', id);
        }
<<<<<<< HEAD

        config.target = "#" + id;
      }

      Util.typeCheckConfig(NAME$8, config, DefaultType$6);
      return config;
    };

    _proto._getScrollTop = function _getScrollTop() {
      return this._scrollElement === window ? this._scrollElement.pageYOffset : this._scrollElement.scrollTop;
    };

    _proto._getScrollHeight = function _getScrollHeight() {
      return this._scrollElement.scrollHeight || Math.max(document.body.scrollHeight, document.documentElement.scrollHeight);
    };

    _proto._getOffsetHeight = function _getOffsetHeight() {
      return this._scrollElement === window ? window.innerHeight : this._scrollElement.getBoundingClientRect().height;
    };

    _proto._process = function _process() {
      var scrollTop = this._getScrollTop() + this._config.offset;

      var scrollHeight = this._getScrollHeight();

      var maxScroll = this._config.offset + scrollHeight - this._getOffsetHeight();
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js


    _getConfig(config) {
      config = { ...Default$1,
        ...Manipulator.getDataAttributes(this._element),
        ...(typeof config === 'object' && config ? config : {})
      };
      config.target = getElement(config.target) || document.documentElement;
      typeCheckConfig(NAME$2, config, DefaultType$1);
      return config;
    }

    _getScrollTop() {
      return this._scrollElement === window ? this._scrollElement.pageYOffset : this._scrollElement.scrollTop;
    }

    _getScrollHeight() {
      return this._scrollElement.scrollHeight || Math.max(document.body.scrollHeight, document.documentElement.scrollHeight);
    }

    _getOffsetHeight() {
      return this._scrollElement === window ? window.innerHeight : this._scrollElement.getBoundingClientRect().height;
    }

    _process() {
      const scrollTop = this._getScrollTop() + this._config.offset;

      const scrollHeight = this._getScrollHeight();

      const maxScroll = this._config.offset + scrollHeight - this._getOffsetHeight();
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277

      if (this._scrollHeight !== scrollHeight) {
        this.refresh();
      }

      if (scrollTop >= maxScroll) {
<<<<<<< HEAD
        var target = this._targets[this._targets.length - 1];
=======
        const target = this._targets[this._targets.length - 1];
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277

        if (this._activeTarget !== target) {
          this._activate(target);
        }

        return;
      }

      if (this._activeTarget && scrollTop < this._offsets[0] && this._offsets[0] > 0) {
        this._activeTarget = null;

        this._clear();

        return;
      }

<<<<<<< HEAD
      for (var i = this._offsets.length; i--;) {
        var isActiveTarget = this._activeTarget !== this._targets[i] && scrollTop >= this._offsets[i] && (typeof this._offsets[i + 1] === 'undefined' || scrollTop < this._offsets[i + 1]);
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      for (let i = this._offsets.length; i--;) {
        const isActiveTarget = this._activeTarget !== this._targets[i] && scrollTop >= this._offsets[i] && (typeof this._offsets[i + 1] === 'undefined' || scrollTop < this._offsets[i + 1]);
========
      for (var i = this._offsets.length; i--;) {
        var isActiveTarget = this._activeTarget !== this._targets[i] && scrollTop >= this._offsets[i] && (typeof this._offsets[i + 1] === 'undefined' || scrollTop < this._offsets[i + 1]);
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277

        if (isActiveTarget) {
          this._activate(this._targets[i]);
        }
      }
<<<<<<< HEAD
    };

    _proto._activate = function _activate(target) {
=======
    }

    _activate(target) {
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      this._activeTarget = target;

      this._clear();

<<<<<<< HEAD
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      const queries = SELECTOR_LINK_ITEMS.split(',').map(selector => `${selector}[data-bs-target="${target}"],${selector}[href="${target}"]`);
      const link = SelectorEngine.findOne(queries.join(','), this._config.target);
      link.classList.add(CLASS_NAME_ACTIVE$1);

      if (link.classList.contains(CLASS_NAME_DROPDOWN_ITEM)) {
        SelectorEngine.findOne(SELECTOR_DROPDOWN_TOGGLE$1, link.closest(SELECTOR_DROPDOWN$1)).classList.add(CLASS_NAME_ACTIVE$1);
      } else {
        SelectorEngine.parents(link, SELECTOR_NAV_LIST_GROUP$1).forEach(listGroup => {
          // Set triggered links parents as active
          // With both <ul> and <nav> markup a parent is the previous sibling of any nav ancestor
          SelectorEngine.prev(listGroup, `${SELECTOR_NAV_LINKS}, ${SELECTOR_LIST_ITEMS}`).forEach(item => item.classList.add(CLASS_NAME_ACTIVE$1)); // Handle special case when .nav-link is inside .nav-item

          SelectorEngine.prev(listGroup, SELECTOR_NAV_ITEMS).forEach(navItem => {
            SelectorEngine.children(navItem, SELECTOR_NAV_LINKS).forEach(item => item.classList.add(CLASS_NAME_ACTIVE$1));
          });
        });
      }

      EventHandler.trigger(this._scrollElement, EVENT_ACTIVATE, {
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      var queries = this._selector.split(',').map(function (selector) {
        return selector + "[data-target=\"" + target + "\"]," + selector + "[href=\"" + target + "\"]";
      });

      var $link = $__default['default']([].slice.call(document.querySelectorAll(queries.join(','))));

      if ($link.hasClass(CLASS_NAME_DROPDOWN_ITEM)) {
        $link.closest(SELECTOR_DROPDOWN).find(SELECTOR_DROPDOWN_TOGGLE).addClass(CLASS_NAME_ACTIVE$2);
        $link.addClass(CLASS_NAME_ACTIVE$2);
      } else {
        // Set triggered link as active
        $link.addClass(CLASS_NAME_ACTIVE$2); // Set triggered links parents as active
        // With both <ul> and <nav> markup a parent is the previous sibling of any nav ancestor

        $link.parents(SELECTOR_NAV_LIST_GROUP).prev(SELECTOR_NAV_LINKS + ", " + SELECTOR_LIST_ITEMS).addClass(CLASS_NAME_ACTIVE$2); // Handle special case when .nav-link is inside .nav-item

        $link.parents(SELECTOR_NAV_LIST_GROUP).prev(SELECTOR_NAV_ITEMS).children(SELECTOR_NAV_LINKS).addClass(CLASS_NAME_ACTIVE$2);
      }

      $__default['default'](this._scrollElement).trigger(EVENT_ACTIVATE, {
<<<<<<< HEAD
        relatedTarget: target
      });
    };

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
        relatedTarget: target
      });
    }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    _clear() {
      SelectorEngine.find(SELECTOR_LINK_ITEMS, this._config.target).filter(node => node.classList.contains(CLASS_NAME_ACTIVE$1)).forEach(node => node.classList.remove(CLASS_NAME_ACTIVE$1));
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    _proto._clear = function _clear() {
      [].slice.call(document.querySelectorAll(this._selector)).filter(function (node) {
        return node.classList.contains(CLASS_NAME_ACTIVE$2);
      }).forEach(function (node) {
        return node.classList.remove(CLASS_NAME_ACTIVE$2);
      });
<<<<<<< HEAD
    } // Static
    ;

    ScrollSpy._jQueryInterface = function _jQueryInterface(config) {
      return this.each(function () {
        var data = $__default['default'](this).data(DATA_KEY$8);

        var _config = typeof config === 'object' && config;

        if (!data) {
          data = new ScrollSpy(this, _config);
          $__default['default'](this).data(DATA_KEY$8, data);
        }

        if (typeof config === 'string') {
          if (typeof data[config] === 'undefined') {
            throw new TypeError("No method named \"" + config + "\"");
          }

          data[config]();
        }
      });
    };

    _createClass(ScrollSpy, null, [{
      key: "VERSION",
      get: function get() {
        return VERSION$8;
      }
    }, {
      key: "Default",
      get: function get() {
        return Default$6;
      }
    }]);

    return ScrollSpy;
  }();
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
    } // Static

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
========
    ScrollSpy._jQueryInterface = function _jQueryInterface(config) {
      return this.each(function () {
        var data = $__default['default'](this).data(DATA_KEY$8);
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

    static jQueryInterface(config) {
      return this.each(function () {
        const data = ScrollSpy.getOrCreateInstance(this, config);

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
        if (typeof config !== 'string') {
          return;
========
        if (!data) {
          data = new ScrollSpy(this, _config);
          $__default['default'](this).data(DATA_KEY$8, data);
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
        }

        if (typeof data[config] === 'undefined') {
          throw new TypeError(`No method named "${config}"`);
        }

        data[config]();
      });
    }

  }
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  /**
   * ------------------------------------------------------------------------
   * Data Api implementation
   * ------------------------------------------------------------------------
   */


<<<<<<< HEAD
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  EventHandler.on(window, EVENT_LOAD_DATA_API, () => {
    SelectorEngine.find(SELECTOR_DATA_SPY).forEach(spy => new ScrollSpy(spy));
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  $__default['default'](window).on(EVENT_LOAD_DATA_API$2, function () {
    var scrollSpys = [].slice.call(document.querySelectorAll(SELECTOR_DATA_SPY));
    var scrollSpysLength = scrollSpys.length;

    for (var i = scrollSpysLength; i--;) {
      var $spy = $__default['default'](scrollSpys[i]);

      ScrollSpy._jQueryInterface.call($spy, $spy.data());
    }
<<<<<<< HEAD
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  });
  /**
   * ------------------------------------------------------------------------
   * jQuery
   * ------------------------------------------------------------------------
<<<<<<< HEAD
   */

=======
   * add .ScrollSpy to jQuery only if jQuery is present
   */

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  defineJQueryPlugin(ScrollSpy);
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  $__default['default'].fn[NAME$8] = ScrollSpy._jQueryInterface;
  $__default['default'].fn[NAME$8].Constructor = ScrollSpy;

  $__default['default'].fn[NAME$8].noConflict = function () {
    $__default['default'].fn[NAME$8] = JQUERY_NO_CONFLICT$8;
    return ScrollSpy._jQueryInterface;
  };
<<<<<<< HEAD

  /**
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

  /**
   * --------------------------------------------------------------------------
   * Bootstrap (v5.1.0): tab.js
   * Licensed under MIT (https://github.com/twbs/bootstrap/blob/main/LICENSE)
   * --------------------------------------------------------------------------
   */
  /**
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
   * ------------------------------------------------------------------------
   * Constants
   * ------------------------------------------------------------------------
   */

<<<<<<< HEAD
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  const NAME$1 = 'tab';
  const DATA_KEY$1 = 'bs.tab';
  const EVENT_KEY$1 = `.${DATA_KEY$1}`;
  const DATA_API_KEY = '.data-api';
  const EVENT_HIDE$1 = `hide${EVENT_KEY$1}`;
  const EVENT_HIDDEN$1 = `hidden${EVENT_KEY$1}`;
  const EVENT_SHOW$1 = `show${EVENT_KEY$1}`;
  const EVENT_SHOWN$1 = `shown${EVENT_KEY$1}`;
  const EVENT_CLICK_DATA_API = `click${EVENT_KEY$1}${DATA_API_KEY}`;
  const CLASS_NAME_DROPDOWN_MENU = 'dropdown-menu';
  const CLASS_NAME_ACTIVE = 'active';
  const CLASS_NAME_FADE$1 = 'fade';
  const CLASS_NAME_SHOW$1 = 'show';
  const SELECTOR_DROPDOWN = '.dropdown';
  const SELECTOR_NAV_LIST_GROUP = '.nav, .list-group';
  const SELECTOR_ACTIVE = '.active';
  const SELECTOR_ACTIVE_UL = ':scope > li > .active';
  const SELECTOR_DATA_TOGGLE = '[data-bs-toggle="tab"], [data-bs-toggle="pill"], [data-bs-toggle="list"]';
  const SELECTOR_DROPDOWN_TOGGLE = '.dropdown-toggle';
  const SELECTOR_DROPDOWN_ACTIVE_CHILD = ':scope > .dropdown-menu .active';
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  var NAME$9 = 'tab';
  var VERSION$9 = '4.6.0';
  var DATA_KEY$9 = 'bs.tab';
  var EVENT_KEY$9 = "." + DATA_KEY$9;
  var DATA_API_KEY$7 = '.data-api';
  var JQUERY_NO_CONFLICT$9 = $__default['default'].fn[NAME$9];
  var EVENT_HIDE$3 = "hide" + EVENT_KEY$9;
  var EVENT_HIDDEN$3 = "hidden" + EVENT_KEY$9;
  var EVENT_SHOW$3 = "show" + EVENT_KEY$9;
  var EVENT_SHOWN$3 = "shown" + EVENT_KEY$9;
  var EVENT_CLICK_DATA_API$6 = "click" + EVENT_KEY$9 + DATA_API_KEY$7;
  var CLASS_NAME_DROPDOWN_MENU = 'dropdown-menu';
  var CLASS_NAME_ACTIVE$3 = 'active';
  var CLASS_NAME_DISABLED$1 = 'disabled';
  var CLASS_NAME_FADE$4 = 'fade';
  var CLASS_NAME_SHOW$6 = 'show';
  var SELECTOR_DROPDOWN$1 = '.dropdown';
  var SELECTOR_NAV_LIST_GROUP$1 = '.nav, .list-group';
  var SELECTOR_ACTIVE$2 = '.active';
  var SELECTOR_ACTIVE_UL = '> li > .active';
  var SELECTOR_DATA_TOGGLE$4 = '[data-toggle="tab"], [data-toggle="pill"], [data-toggle="list"]';
  var SELECTOR_DROPDOWN_TOGGLE$1 = '.dropdown-toggle';
  var SELECTOR_DROPDOWN_ACTIVE_CHILD = '> .dropdown-menu .active';
<<<<<<< HEAD
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  /**
   * ------------------------------------------------------------------------
   * Class Definition
   * ------------------------------------------------------------------------
   */
<<<<<<< HEAD
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277

  var Tab = /*#__PURE__*/function () {
    function Tab(element) {
      this._element = element;
    } // Getters

<<<<<<< HEAD

    var _proto = Tab.prototype;

    // Public
    _proto.show = function show() {
      var _this = this;

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

  class Tab extends BaseComponent {
    // Getters
    static get NAME() {
      return NAME$1;
    } // Public


<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    show() {
      if (this._element.parentNode && this._element.parentNode.nodeType === Node.ELEMENT_NODE && this._element.classList.contains(CLASS_NAME_ACTIVE)) {
        return;
      }

      let previous;
      const target = getElementFromSelector(this._element);

      const listElement = this._element.closest(SELECTOR_NAV_LIST_GROUP);

      if (listElement) {
        const itemSelector = listElement.nodeName === 'UL' || listElement.nodeName === 'OL' ? SELECTOR_ACTIVE_UL : SELECTOR_ACTIVE;
        previous = SelectorEngine.find(itemSelector, listElement);
        previous = previous[previous.length - 1];
      }

      const hideEvent = previous ? EventHandler.trigger(previous, EVENT_HIDE$1, {
        relatedTarget: this._element
      }) : null;
      const showEvent = EventHandler.trigger(this._element, EVENT_SHOW$1, {
        relatedTarget: previous
      });

      if (showEvent.defaultPrevented || hideEvent !== null && hideEvent.defaultPrevented) {
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      if (this._element.parentNode && this._element.parentNode.nodeType === Node.ELEMENT_NODE && $__default['default'](this._element).hasClass(CLASS_NAME_ACTIVE$3) || $__default['default'](this._element).hasClass(CLASS_NAME_DISABLED$1)) {
        return;
      }

      var target;
      var previous;
      var listElement = $__default['default'](this._element).closest(SELECTOR_NAV_LIST_GROUP$1)[0];
      var selector = Util.getSelectorFromElement(this._element);

      if (listElement) {
        var itemSelector = listElement.nodeName === 'UL' || listElement.nodeName === 'OL' ? SELECTOR_ACTIVE_UL : SELECTOR_ACTIVE$2;
        previous = $__default['default'].makeArray($__default['default'](listElement).find(itemSelector));
        previous = previous[previous.length - 1];
      }

      var hideEvent = $__default['default'].Event(EVENT_HIDE$3, {
        relatedTarget: this._element
      });
      var showEvent = $__default['default'].Event(EVENT_SHOW$3, {
        relatedTarget: previous
      });

      if (previous) {
        $__default['default'](previous).trigger(hideEvent);
      }

      $__default['default'](this._element).trigger(showEvent);

      if (showEvent.isDefaultPrevented() || hideEvent.isDefaultPrevented()) {
<<<<<<< HEAD
        return;
      }

      if (selector) {
        target = document.querySelector(selector);
      }

      this._activate(this._element, listElement);

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
        return;
      }

      this._activate(this._element, listElement);

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      const complete = () => {
        EventHandler.trigger(previous, EVENT_HIDDEN$1, {
          relatedTarget: this._element
        });
        EventHandler.trigger(this._element, EVENT_SHOWN$1, {
          relatedTarget: previous
        });
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      var complete = function complete() {
        var hiddenEvent = $__default['default'].Event(EVENT_HIDDEN$3, {
          relatedTarget: _this._element
        });
        var shownEvent = $__default['default'].Event(EVENT_SHOWN$3, {
          relatedTarget: previous
        });
        $__default['default'](previous).trigger(hiddenEvent);
        $__default['default'](_this._element).trigger(shownEvent);
<<<<<<< HEAD
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      };

      if (target) {
        this._activate(target, target.parentNode, complete);
      } else {
        complete();
      }
<<<<<<< HEAD
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    };

    _proto.dispose = function dispose() {
      $__default['default'].removeData(this._element, DATA_KEY$9);
      this._element = null;
<<<<<<< HEAD
    } // Private
    ;

    _proto._activate = function _activate(element, container, callback) {
      var _this2 = this;

      var activeElements = container && (container.nodeName === 'UL' || container.nodeName === 'OL') ? $__default['default'](container).find(SELECTOR_ACTIVE_UL) : $__default['default'](container).children(SELECTOR_ACTIVE$2);
      var active = activeElements[0];
      var isTransitioning = callback && active && $__default['default'](active).hasClass(CLASS_NAME_FADE$4);

      var complete = function complete() {
        return _this2._transitionComplete(element, active, callback);
      };

      if (active && isTransitioning) {
        var transitionDuration = Util.getTransitionDurationFromElement(active);
        $__default['default'](active).removeClass(CLASS_NAME_SHOW$6).one(Util.TRANSITION_END, complete).emulateTransitionEnd(transitionDuration);
      } else {
        complete();
      }
    };

    _proto._transitionComplete = function _transitionComplete(element, active, callback) {
      if (active) {
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
    } // Private


<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    _activate(element, container, callback) {
      const activeElements = container && (container.nodeName === 'UL' || container.nodeName === 'OL') ? SelectorEngine.find(SELECTOR_ACTIVE_UL, container) : SelectorEngine.children(container, SELECTOR_ACTIVE);
      const active = activeElements[0];
      const isTransitioning = callback && active && active.classList.contains(CLASS_NAME_FADE$1);
========
      var activeElements = container && (container.nodeName === 'UL' || container.nodeName === 'OL') ? $__default['default'](container).find(SELECTOR_ACTIVE_UL) : $__default['default'](container).children(SELECTOR_ACTIVE$2);
      var active = activeElements[0];
      var isTransitioning = callback && active && $__default['default'](active).hasClass(CLASS_NAME_FADE$4);
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

      const complete = () => this._transitionComplete(element, active, callback);

      if (active && isTransitioning) {
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
        active.classList.remove(CLASS_NAME_SHOW$1);

        this._queueCallback(complete, element, true);
========
        var transitionDuration = Util.getTransitionDurationFromElement(active);
        $__default['default'](active).removeClass(CLASS_NAME_SHOW$6).one(Util.TRANSITION_END, complete).emulateTransitionEnd(transitionDuration);
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
      } else {
        complete();
      }
    }

    _transitionComplete(element, active, callback) {
      if (active) {
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
        active.classList.remove(CLASS_NAME_ACTIVE);
        const dropdownChild = SelectorEngine.findOne(SELECTOR_DROPDOWN_ACTIVE_CHILD, active.parentNode);

        if (dropdownChild) {
          dropdownChild.classList.remove(CLASS_NAME_ACTIVE);
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
        $__default['default'](active).removeClass(CLASS_NAME_ACTIVE$3);
        var dropdownChild = $__default['default'](active.parentNode).find(SELECTOR_DROPDOWN_ACTIVE_CHILD)[0];

        if (dropdownChild) {
          $__default['default'](dropdownChild).removeClass(CLASS_NAME_ACTIVE$3);
<<<<<<< HEAD
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
        }

        if (active.getAttribute('role') === 'tab') {
          active.setAttribute('aria-selected', false);
        }
      }

<<<<<<< HEAD
      $__default['default'](element).addClass(CLASS_NAME_ACTIVE$3);
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      element.classList.add(CLASS_NAME_ACTIVE);
========
      $__default['default'](element).addClass(CLASS_NAME_ACTIVE$3);
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277

      if (element.getAttribute('role') === 'tab') {
        element.setAttribute('aria-selected', true);
      }

<<<<<<< HEAD
      Util.reflow(element);

=======
      reflow(element);

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
      if (element.classList.contains(CLASS_NAME_FADE$1)) {
        element.classList.add(CLASS_NAME_SHOW$1);
      }

      let parent = element.parentNode;

      if (parent && parent.nodeName === 'LI') {
        parent = parent.parentNode;
      }

      if (parent && parent.classList.contains(CLASS_NAME_DROPDOWN_MENU)) {
        const dropdownElement = element.closest(SELECTOR_DROPDOWN);

        if (dropdownElement) {
          SelectorEngine.find(SELECTOR_DROPDOWN_TOGGLE, dropdownElement).forEach(dropdown => dropdown.classList.add(CLASS_NAME_ACTIVE));
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      if (element.classList.contains(CLASS_NAME_FADE$4)) {
        element.classList.add(CLASS_NAME_SHOW$6);
      }

      if (element.parentNode && $__default['default'](element.parentNode).hasClass(CLASS_NAME_DROPDOWN_MENU)) {
        var dropdownElement = $__default['default'](element).closest(SELECTOR_DROPDOWN$1)[0];

        if (dropdownElement) {
          var dropdownToggleList = [].slice.call(dropdownElement.querySelectorAll(SELECTOR_DROPDOWN_TOGGLE$1));
          $__default['default'](dropdownToggleList).addClass(CLASS_NAME_ACTIVE$3);
<<<<<<< HEAD
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
        }

        element.setAttribute('aria-expanded', true);
      }

      if (callback) {
        callback();
      }
    } // Static
<<<<<<< HEAD
    ;

=======

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    Tab._jQueryInterface = function _jQueryInterface(config) {
      return this.each(function () {
        var $this = $__default['default'](this);
        var data = $this.data(DATA_KEY$9);
<<<<<<< HEAD

        if (!data) {
          data = new Tab(this);
          $this.data(DATA_KEY$9, data);
        }

        if (typeof config === 'string') {
          if (typeof data[config] === 'undefined') {
            throw new TypeError("No method named \"" + config + "\"");
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

    static jQueryInterface(config) {
      return this.each(function () {
        const data = Tab.getOrCreateInstance(this);

        if (typeof config === 'string') {
          if (typeof data[config] === 'undefined') {
            throw new TypeError(`No method named "${config}"`);
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
          }

          data[config]();
        }
      });
<<<<<<< HEAD
    };

    _createClass(Tab, null, [{
      key: "VERSION",
      get: function get() {
        return VERSION$9;
      }
    }]);

    return Tab;
  }();
=======
    }

  }
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  /**
   * ------------------------------------------------------------------------
   * Data Api implementation
   * ------------------------------------------------------------------------
   */


<<<<<<< HEAD
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  EventHandler.on(document, EVENT_CLICK_DATA_API, SELECTOR_DATA_TOGGLE, function (event) {
    if (['A', 'AREA'].includes(this.tagName)) {
      event.preventDefault();
    }

    if (isDisabled(this)) {
      return;
    }

    const data = Tab.getOrCreateInstance(this);
    data.show();
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  $__default['default'](document).on(EVENT_CLICK_DATA_API$6, SELECTOR_DATA_TOGGLE$4, function (event) {
    event.preventDefault();

    Tab._jQueryInterface.call($__default['default'](this), 'show');
<<<<<<< HEAD
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  });
  /**
   * ------------------------------------------------------------------------
   * jQuery
   * ------------------------------------------------------------------------
<<<<<<< HEAD
   */

=======
   * add .Tab to jQuery only if jQuery is present
   */

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  defineJQueryPlugin(Tab);
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  $__default['default'].fn[NAME$9] = Tab._jQueryInterface;
  $__default['default'].fn[NAME$9].Constructor = Tab;

  $__default['default'].fn[NAME$9].noConflict = function () {
    $__default['default'].fn[NAME$9] = JQUERY_NO_CONFLICT$9;
    return Tab._jQueryInterface;
  };
<<<<<<< HEAD

  /**
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

  /**
   * --------------------------------------------------------------------------
   * Bootstrap (v5.1.0): toast.js
   * Licensed under MIT (https://github.com/twbs/bootstrap/blob/main/LICENSE)
   * --------------------------------------------------------------------------
   */
  /**
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
   * ------------------------------------------------------------------------
   * Constants
   * ------------------------------------------------------------------------
   */

<<<<<<< HEAD
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  const NAME = 'toast';
  const DATA_KEY = 'bs.toast';
  const EVENT_KEY = `.${DATA_KEY}`;
  const EVENT_MOUSEOVER = `mouseover${EVENT_KEY}`;
  const EVENT_MOUSEOUT = `mouseout${EVENT_KEY}`;
  const EVENT_FOCUSIN = `focusin${EVENT_KEY}`;
  const EVENT_FOCUSOUT = `focusout${EVENT_KEY}`;
  const EVENT_HIDE = `hide${EVENT_KEY}`;
  const EVENT_HIDDEN = `hidden${EVENT_KEY}`;
  const EVENT_SHOW = `show${EVENT_KEY}`;
  const EVENT_SHOWN = `shown${EVENT_KEY}`;
  const CLASS_NAME_FADE = 'fade';
  const CLASS_NAME_HIDE = 'hide'; // @deprecated - kept here only for backwards compatibility

  const CLASS_NAME_SHOW = 'show';
  const CLASS_NAME_SHOWING = 'showing';
  const DefaultType = {
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  var NAME$a = 'toast';
  var VERSION$a = '4.6.0';
  var DATA_KEY$a = 'bs.toast';
  var EVENT_KEY$a = "." + DATA_KEY$a;
  var JQUERY_NO_CONFLICT$a = $__default['default'].fn[NAME$a];
  var EVENT_CLICK_DISMISS$1 = "click.dismiss" + EVENT_KEY$a;
  var EVENT_HIDE$4 = "hide" + EVENT_KEY$a;
  var EVENT_HIDDEN$4 = "hidden" + EVENT_KEY$a;
  var EVENT_SHOW$4 = "show" + EVENT_KEY$a;
  var EVENT_SHOWN$4 = "shown" + EVENT_KEY$a;
  var CLASS_NAME_FADE$5 = 'fade';
  var CLASS_NAME_HIDE = 'hide';
  var CLASS_NAME_SHOW$7 = 'show';
  var CLASS_NAME_SHOWING = 'showing';
  var DefaultType$7 = {
<<<<<<< HEAD
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    animation: 'boolean',
    autohide: 'boolean',
    delay: 'number'
  };
<<<<<<< HEAD
  var Default$7 = {
    animation: true,
    autohide: true,
    delay: 500
  };
  var SELECTOR_DATA_DISMISS$1 = '[data-dismiss="toast"]';
=======
  const Default = {
    animation: true,
    autohide: true,
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    delay: 5000
  };
========
    delay: 500
  };
  var SELECTOR_DATA_DISMISS$1 = '[data-dismiss="toast"]';
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  /**
   * ------------------------------------------------------------------------
   * Class Definition
   * ------------------------------------------------------------------------
   */

<<<<<<< HEAD
  var Toast = /*#__PURE__*/function () {
    function Toast(element, config) {
      this._element = element;
      this._config = this._getConfig(config);
      this._timeout = null;
=======
<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  class Toast extends BaseComponent {
    constructor(element, config) {
      super(element);
========
  var Toast = /*#__PURE__*/function () {
    function Toast(element, config) {
      this._element = element;
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
      this._config = this._getConfig(config);
      this._timeout = null;
      this._hasMouseInteraction = false;
      this._hasKeyboardInteraction = false;
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277

      this._setListeners();
    } // Getters


<<<<<<< HEAD
    var _proto = Toast.prototype;

    // Public
    _proto.show = function show() {
      var _this = this;

=======
    static get DefaultType() {
      return DefaultType;
    }

    static get Default() {
      return Default;
    }

    static get NAME() {
      return NAME;
    } // Public


<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    show() {
      const showEvent = EventHandler.trigger(this._element, EVENT_SHOW);

      if (showEvent.defaultPrevented) {
        return;
      }

      this._clearTimeout();

      if (this._config.animation) {
        this._element.classList.add(CLASS_NAME_FADE);
      }

      const complete = () => {
        this._element.classList.remove(CLASS_NAME_SHOWING);

        EventHandler.trigger(this._element, EVENT_SHOWN);

        this._maybeScheduleHide();
      };

      this._element.classList.remove(CLASS_NAME_HIDE); // @deprecated


      reflow(this._element);

      this._element.classList.add(CLASS_NAME_SHOW);

      this._element.classList.add(CLASS_NAME_SHOWING);

      this._queueCallback(complete, this._element, this._config.animation);
    }

    hide() {
      if (!this._element.classList.contains(CLASS_NAME_SHOW)) {
        return;
      }

      const hideEvent = EventHandler.trigger(this._element, EVENT_HIDE);

      if (hideEvent.defaultPrevented) {
        return;
      }

      const complete = () => {
        this._element.classList.add(CLASS_NAME_HIDE); // @deprecated


        this._element.classList.remove(CLASS_NAME_SHOWING);

        this._element.classList.remove(CLASS_NAME_SHOW);

        EventHandler.trigger(this._element, EVENT_HIDDEN);
      };

      this._element.classList.add(CLASS_NAME_SHOWING);

      this._queueCallback(complete, this._element, this._config.animation);
    }

    dispose() {
      this._clearTimeout();

      if (this._element.classList.contains(CLASS_NAME_SHOW)) {
        this._element.classList.remove(CLASS_NAME_SHOW);
      }

      super.dispose();
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
      var showEvent = $__default['default'].Event(EVENT_SHOW$4);
      $__default['default'](this._element).trigger(showEvent);

      if (showEvent.isDefaultPrevented()) {
        return;
      }

      this._clearTimeout();

      if (this._config.animation) {
        this._element.classList.add(CLASS_NAME_FADE$5);
      }

      var complete = function complete() {
        _this._element.classList.remove(CLASS_NAME_SHOWING);

        _this._element.classList.add(CLASS_NAME_SHOW$7);

        $__default['default'](_this._element).trigger(EVENT_SHOWN$4);

        if (_this._config.autohide) {
          _this._timeout = setTimeout(function () {
            _this.hide();
          }, _this._config.delay);
        }
      };

      this._element.classList.remove(CLASS_NAME_HIDE);

      Util.reflow(this._element);

      this._element.classList.add(CLASS_NAME_SHOWING);

      if (this._config.animation) {
        var transitionDuration = Util.getTransitionDurationFromElement(this._element);
        $__default['default'](this._element).one(Util.TRANSITION_END, complete).emulateTransitionEnd(transitionDuration);
      } else {
        complete();
      }
    };

    _proto.hide = function hide() {
      if (!this._element.classList.contains(CLASS_NAME_SHOW$7)) {
        return;
      }

      var hideEvent = $__default['default'].Event(EVENT_HIDE$4);
      $__default['default'](this._element).trigger(hideEvent);

      if (hideEvent.isDefaultPrevented()) {
        return;
      }

      this._close();
    };

    _proto.dispose = function dispose() {
      this._clearTimeout();

      if (this._element.classList.contains(CLASS_NAME_SHOW$7)) {
        this._element.classList.remove(CLASS_NAME_SHOW$7);
      }

      $__default['default'](this._element).off(EVENT_CLICK_DISMISS$1);
      $__default['default'].removeData(this._element, DATA_KEY$a);
      this._element = null;
      this._config = null;
<<<<<<< HEAD
    } // Private
    ;

    _proto._getConfig = function _getConfig(config) {
      config = _extends({}, Default$7, $__default['default'](this._element).data(), typeof config === 'object' && config ? config : {});
      Util.typeCheckConfig(NAME$a, config, this.constructor.DefaultType);
      return config;
    };

=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
    } // Private

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js

    _getConfig(config) {
      config = { ...Default,
        ...Manipulator.getDataAttributes(this._element),
        ...(typeof config === 'object' && config ? config : {})
      };
      typeCheckConfig(NAME, config, this.constructor.DefaultType);
========
    _proto._getConfig = function _getConfig(config) {
      config = _extends({}, Default$7, $__default['default'](this._element).data(), typeof config === 'object' && config ? config : {});
      Util.typeCheckConfig(NAME$a, config, this.constructor.DefaultType);
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
      return config;
    }

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
    _maybeScheduleHide() {
      if (!this._config.autohide) {
        return;
      }

      if (this._hasMouseInteraction || this._hasKeyboardInteraction) {
        return;
      }

      this._timeout = setTimeout(() => {
        this.hide();
      }, this._config.delay);
    }

    _onInteraction(event, isInteracting) {
      switch (event.type) {
        case 'mouseover':
        case 'mouseout':
          this._hasMouseInteraction = isInteracting;
          break;

        case 'focusin':
        case 'focusout':
          this._hasKeyboardInteraction = isInteracting;
          break;
      }

      if (isInteracting) {
        this._clearTimeout();

        return;
      }

      const nextElement = event.relatedTarget;

      if (this._element === nextElement || this._element.contains(nextElement)) {
        return;
      }
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
    _proto._setListeners = function _setListeners() {
      var _this2 = this;

      $__default['default'](this._element).on(EVENT_CLICK_DISMISS$1, SELECTOR_DATA_DISMISS$1, function () {
        return _this2.hide();
      });
    };

    _proto._close = function _close() {
      var _this3 = this;

      var complete = function complete() {
        _this3._element.classList.add(CLASS_NAME_HIDE);

        $__default['default'](_this3._element).trigger(EVENT_HIDDEN$4);
      };

      this._element.classList.remove(CLASS_NAME_SHOW$7);

      if (this._config.animation) {
        var transitionDuration = Util.getTransitionDurationFromElement(this._element);
        $__default['default'](this._element).one(Util.TRANSITION_END, complete).emulateTransitionEnd(transitionDuration);
      } else {
        complete();
      }
    };

    _proto._clearTimeout = function _clearTimeout() {
      clearTimeout(this._timeout);
      this._timeout = null;
    } // Static
    ;

    Toast._jQueryInterface = function _jQueryInterface(config) {
      return this.each(function () {
        var $element = $__default['default'](this);
        var data = $element.data(DATA_KEY$a);
<<<<<<< HEAD

        var _config = typeof config === 'object' && config;

        if (!data) {
          data = new Toast(this, _config);
          $element.data(DATA_KEY$a, data);
        }

        if (typeof config === 'string') {
          if (typeof data[config] === 'undefined') {
            throw new TypeError("No method named \"" + config + "\"");
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js

      this._maybeScheduleHide();
    }

    _setListeners() {
      EventHandler.on(this._element, EVENT_MOUSEOVER, event => this._onInteraction(event, true));
      EventHandler.on(this._element, EVENT_MOUSEOUT, event => this._onInteraction(event, false));
      EventHandler.on(this._element, EVENT_FOCUSIN, event => this._onInteraction(event, true));
      EventHandler.on(this._element, EVENT_FOCUSOUT, event => this._onInteraction(event, false));
    }

    _clearTimeout() {
      clearTimeout(this._timeout);
      this._timeout = null;
    } // Static


    static jQueryInterface(config) {
      return this.each(function () {
        const data = Toast.getOrCreateInstance(this, config);

        if (typeof config === 'string') {
          if (typeof data[config] === 'undefined') {
            throw new TypeError(`No method named "${config}"`);
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
          }

          data[config](this);
        }
      });
<<<<<<< HEAD
    };

    _createClass(Toast, null, [{
      key: "VERSION",
      get: function get() {
        return VERSION$a;
      }
    }, {
      key: "DefaultType",
      get: function get() {
        return DefaultType$7;
      }
    }, {
      key: "Default",
      get: function get() {
        return Default$7;
      }
    }]);

    return Toast;
  }();
=======
    }

  }

  enableDismissTrigger(Toast);
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277
  /**
   * ------------------------------------------------------------------------
   * jQuery
   * ------------------------------------------------------------------------
<<<<<<< HEAD
   */

=======
   * add .Toast to jQuery only if jQuery is present
   */

<<<<<<<< HEAD:src/frontend/ServicesDeskUCAB/wwwroot/lib/bootstrap/dist/js/bootstrap.js
  defineJQueryPlugin(Toast);

  /**
   * --------------------------------------------------------------------------
   * Bootstrap (v5.1.0): index.umd.js
   * Licensed under MIT (https://github.com/twbs/bootstrap/blob/main/LICENSE)
   * --------------------------------------------------------------------------
   */
  var index_umd = {
    Alert,
    Button,
    Carousel,
    Collapse,
    Dropdown,
    Modal,
    Offcanvas,
    Popover,
    ScrollSpy,
    Tab,
    Toast,
    Tooltip
  };

  return index_umd;
========
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277

  $__default['default'].fn[NAME$a] = Toast._jQueryInterface;
  $__default['default'].fn[NAME$a].Constructor = Toast;

  $__default['default'].fn[NAME$a].noConflict = function () {
    $__default['default'].fn[NAME$a] = JQUERY_NO_CONFLICT$a;
    return Toast._jQueryInterface;
  };

  exports.Alert = Alert;
  exports.Button = Button;
  exports.Carousel = Carousel;
  exports.Collapse = Collapse;
  exports.Dropdown = Dropdown;
  exports.Modal = Modal;
  exports.Popover = Popover;
  exports.Scrollspy = ScrollSpy;
  exports.Tab = Tab;
  exports.Toast = Toast;
  exports.Tooltip = Tooltip;
  exports.Util = Util;

  Object.defineProperty(exports, '__esModule', { value: true });
<<<<<<< HEAD
=======
>>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277:src/frontend/ServiceDeskUCAB/wwwroot/vendor/bootstrap/js/bootstrap.js
>>>>>>> cfb44ab52bfe93e7ce40f069fa382f6f065a0277

})));
//# sourceMappingURL=bootstrap.js.map
